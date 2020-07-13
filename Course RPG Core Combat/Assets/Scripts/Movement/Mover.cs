using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        NavMeshAgent _playerNavMeshAgent;
        Animator _playerAnimator;

        private void Start()
        {
            _playerNavMeshAgent = GetComponent<NavMeshAgent>();
            _playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            _playerNavMeshAgent.destination = destination;
            _playerNavMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            _playerNavMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = _playerNavMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            _playerAnimator.SetFloat("Forward Speed", speed);
        }
    }
}