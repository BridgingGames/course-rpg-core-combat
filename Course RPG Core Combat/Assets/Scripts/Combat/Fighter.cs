using UnityEngine;
using RPG.Movement;
using RPG.Core;
using RPG.UI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float _weaponRange = 1f;
        [SerializeField] float _timeBetweenAttacks = 1f;
        [SerializeField] int _weaponDamage = 1;
        private Health _target;
        float _timeSinceLastAttack = 0;

        private void Update()
        {
            if (_target == null) return;
            if (_target.IsDead()) return;

            if (!IsInRange()) GetComponent<Mover>().MoveTo(_target.transform.position);
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
                _target.TakeDamage(_weaponDamage);

                // Additional Content
                GetComponent<PopUpsController>().DamagePopUp(_weaponDamage, _target.transform);
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
            return Vector3.Distance(transform.position, _target.transform.position) < _weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetTrigger("stopAttack");
            _target = null;
        }
    }
}