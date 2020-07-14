using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float _health = 100;
        // Additional Content
        [SerializeField] Transform _damagePopUp = null;

        public void TakeDamage(float damage)
        {
            _health =  Mathf.Max(_health - damage, 0);
            print(_health);
            // Additional Content
            PopUpDamage(damage);
        }

        // Additional Content
        private void PopUpDamage(float damage)
        {
            Vector3 textPosition = transform.position + new Vector3(0, 2.5f, 0);
            Transform popUpTransform = Instantiate(_damagePopUp, textPosition, transform.rotation);
            DamagePopUp damagePopUp = popUpTransform.GetComponent<DamagePopUp>();
            damagePopUp.Setup(damage);
        }
    }
}
