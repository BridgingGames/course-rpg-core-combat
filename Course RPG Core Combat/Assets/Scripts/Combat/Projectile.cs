using RPG.Core;
using RPG.UI;
using UnityEngine;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float arrowSpeed = 2f;
        [SerializeField] bool isHoming = true;
        [SerializeField] GameObject hitEffect = null;
        Health target = null;
        float damage = 0;

        private void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        private void Update()
        {
            if (target == null) return;

            if (isHoming && !target.IsDead())
            {
                transform.LookAt(GetAimLocation());
            }
            
            transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);
        }

        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if(targetCapsule == null)
            {
                return target.transform.position;
            }

            return target.transform.position + (Vector3.up * targetCapsule.height / 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != target) return;
            if (target.IsDead()) return;

            target.TakeDamage(damage);

            if(hitEffect != null)
            {
                Instantiate(hitEffect, GetAimLocation(), transform.rotation); 
            }

            /* Additional */
            target.GetComponent<PopUpsController>().DamagePopUp(damage, target.transform);

            Destroy(gameObject);
        }
    }
}