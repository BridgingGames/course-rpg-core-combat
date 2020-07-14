using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        // Variables.
        [SerializeField] float _weaponRange = 2f;
        [SerializeField] float _timeBetweenAttacks = 1f;
        private Transform _target;
        float _timeSinceLastAttack = 0;

        private void Update()
        {
            /* Moving to Target Section;
             * If the target is null, returns;
             * If IsInRange() returns false, move player to the target position;
             * If IsInRange() returns true, stop the player. */
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
                GetComponent<Animator>().SetTrigger("attack");
                _timeSinceLastAttack = 0;
            }
        }

        /* Method that calculate if the distance between the player and the target is smaller than the weapon range;
         * Returns a boolean. */
        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.position) < _weaponRange;
        }

        /* Method that receives a CombatTarget and start the combat;
         * Start the combat action by the ActionScheduler;
         * Current target becomes the target received. */
        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.transform;
        }

        /* Method that cancels the attack action;
         * Nullify the current target. */
        public void Cancel()
        {
            _target = null;
        }

        // Animation Event.
        void Hit()
        {
            _target.GetComponent<Health>().TakeDamage(Random.Range(1, 9) + 10);
        }
    }
}