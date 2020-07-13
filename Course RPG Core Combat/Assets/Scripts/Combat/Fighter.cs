using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float _weaponRange = 2f;

        public Transform _target;

        private void Update()
        {
            if (_target != null) return;
            if (!IsInRange())
            {
                GetComponent<Mover>().MoveTo(_target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.position) < _weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            _target = combatTarget.transform;
            print("Where's the money Lebowski?");
        }

        public void Cancel()
        {
            _target = null;
        }
    }
}