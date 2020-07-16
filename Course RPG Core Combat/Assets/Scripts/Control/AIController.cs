using UnityEngine;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float _chaseDistance = 5f;
        private Health health = null;
        private Fighter fighter = null;
        private GameObject player = null;

        private void Start()
        {
            health = GetComponent<Health>();
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");

        }

        private void Update()
        {
            if (health.IsDead()) return;

            if (InAttackRange(player) && GetComponent<Fighter>().CanAttack(player))
            {
                print(transform.name + ": Never should've come here!");
                GetComponent<Fighter>().Attack(player);
            }
            else 
            {
                fighter.Cancel();
            }
        }

        private bool InAttackRange(GameObject target)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < _chaseDistance;
        }
    }
}
