using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float _healthPoints = 100;
        bool _isDead = false;

        public bool IsDead()
        {
            return _isDead;
        }

        public void TakeDamage(float damage)
        {
            _healthPoints = Mathf.Max(_healthPoints - damage, 0);

            if (_healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_isDead) return;
            _isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}