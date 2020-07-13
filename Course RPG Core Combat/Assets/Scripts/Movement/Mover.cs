using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        // Variables.
        private NavMeshAgent _playerNavMeshAgent;

        private void Start()
        {
            // Set attached components.
            _playerNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            // Update the animation state.
            UpdateAnimator();
        }

        /* Method that receives a Vector3 and starts the movement action;
         * Start the movemente action by the ActionScheduler;
         * Move to the received position. */
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        /* Method that receives a Vector3 and moves the player;
         * Current player NavMeshAgen destination is replaced by the received position;
         * NavMeshAgent isn't stopped no more.
         * */
        public void MoveTo(Vector3 destination)
        {
            _playerNavMeshAgent.destination = destination;
            _playerNavMeshAgent.isStopped = false;
        }

        /* Method that cancels the movement action;
         * NavMeshAgent is stopped. */
        public void Cancel()
        {
            _playerNavMeshAgent.isStopped = true;
        }

        /* Method that updates the Animator;
         * Gets current player NavMeshAgent world space velocity and transforms into local space velocity;
         * Applies local space velocity to the Animator "forwardSpeed" value. */
        private void UpdateAnimator()
        {
            Vector3 velocity = _playerNavMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}