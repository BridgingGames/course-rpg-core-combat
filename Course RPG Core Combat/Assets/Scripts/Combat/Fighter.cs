using UnityEngine;
using RPG.Movement;
using RPG.Core;
using RPG.UI;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float _weaponRange = 1f;
        [SerializeField] float _timeBetweenAttacks = 1f;
        [SerializeField] int _weaponDamage = 1;
        private Health _target;
        private float _timeSinceLastAttack = 0;

        private void Start()
        {
            _timeSinceLastAttack = Mathf.Infinity;
        }

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

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.GetComponent<Health>();
        }

        private void AttackBehaviour()
        {
            transform.LookAt(_target.transform);

            if (_timeSinceLastAttack >= _timeBetweenAttacks)
            {
                TriggerAttack();
                _timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        public void Cancel()
        {
            StopAttack();
            _target = null;
        }

        private void StopAttack()
        {
            // This will trigger the Hit() event.
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.transform.position) < _weaponRange;
        }

        // Animation Event.
        void Hit()
        {
            if (_target == null) return;
            _target.TakeDamage(_weaponDamage);

            // Additional Content
            GetComponent<PopUpsController>().DamagePopUp(_weaponDamage, _target.transform);
        }

        // Animation Event.
        void FootR()
        {
            return;
        }

        // Animation Event.
        void FootL()
        {
            return;
        }
    }
}