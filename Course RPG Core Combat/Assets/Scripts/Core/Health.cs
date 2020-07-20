using UnityEngine;

/* Additional */
using RPG.Sounds;

namespace RPG.Core
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
            GetComponent<SoundController>().PlayDeathSoundEffect();
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}