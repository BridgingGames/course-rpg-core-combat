using UnityEngine;
using RPG.Movement;
using RPG.Core;

/* Additional */
using RPG.UI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float _timeBetweenAttacks = 1f;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] Weapon defaultWeapon = null;

        public Health _target;
        private float _timeSinceLastAttack = Mathf.Infinity;
        Weapon currentWeapon = null;

        private void Awake()
        { 
            EquipWeapon(defaultWeapon);
        }

        private void Start()
        {
             
        }

        private void Update()
        {
            if (_target == null) return;
            if (_target.IsDead()) return;

            if (!IsInRange())
            {
                GetComponent<Mover>().MoveTo(_target.transform.position, 1f);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }

            _timeSinceLastAttack += Time.deltaTime;
        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(rightHandTransform, leftHandTransform, animator);
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
            GetComponent<Mover>().Cancel();
        }

        private void StopAttack()
        {
            // This will trigger the Hit() event.
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.transform.position) < currentWeapon.GetRange();
        }

        // Animation Event.
        void Hit()
        {
            if (_target == null) return;

            if (currentWeapon.HasProjectile())
            {
                currentWeapon.LaunchProjectile(rightHandTransform, leftHandTransform, _target);
            }
            else
            {
                _target.TakeDamage(currentWeapon.GetDamage());

                /* Additional */
                this.GetComponent<PopUpsController>().DamagePopUp(currentWeapon.GetDamage(), _target.transform);
            }
        }

        // Animation Event.
        void Shoot()
        {
            Hit();
        }

        // Animation Event.
        void FootR()
        {

        }

        // Animation Event.
        void FootL()
        {

        }
    }
}