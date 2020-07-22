using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float healthPoints = 1f;
        private bool isDead = false;

        // Returns if the character is dead or not.
        public bool IsDead()
        {
            return isDead;
        }

        // Receives damage and subtract It from the health points, also It can't go lower than 0;
        // If health points equal 0, kills the character.
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);

            if (healthPoints == 0)
            {
                Die();
            }
        }

        // If character is dead, don't kill It again, otherwise, flag It as dead;
        // Also, trigger death animation, cancel any current action.
        private void Die()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}