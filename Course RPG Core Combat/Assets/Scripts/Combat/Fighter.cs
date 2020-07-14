using UnityEngine;
using RPG.Movement;
using RPG.Core;
using RPG.UI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float _weaponRange = 2f;
        [SerializeField] float _timeBetweenAttacks = 1f;
        [SerializeField][Range(1, 20)] int _weaponDamage = 1;
        private Transform _target;
        float _timeSinceLastAttack = 0;

        private void Update()
        {
            if (_target == null) return;
            if (!IsInRange()) GetComponent<Mover>().MoveTo(_target.position);
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }

            _timeSinceLastAttack += Time.deltaTime;
        }

        private void AttackBehaviour()
        {
            if (_timeSinceLastAttack >= _timeBetweenAttacks)
            {
                // This wioll trigger the Hit() event.
                GetComponent<Animator>().SetTrigger("attack");
                _timeSinceLastAttack = 0;
            }
        }

        // Animation Event.
        void Hit()
        {
            if (_target != null)
            {
                Health targetHealth = _target.GetComponent<Health>();
                targetHealth.TakeDamage(_weaponDamage);

                // Additional Content
                GetComponent<PopUpsController>().DamagePopUp(_weaponDamage, _target);
            }
        }

        void FootR()
        {
            return;
        }

        void FootL()
        {
            return;
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.position) < _weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.transform;
        }

        public void Cancel()
        {
            _target = null;
        }
    }
}