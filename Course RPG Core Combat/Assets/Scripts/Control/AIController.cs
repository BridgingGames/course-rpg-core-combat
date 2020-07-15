using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float _chaseDistance = 5f;
        GameObject player = null;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (DistanceToPlayer() <= _chaseDistance)
            {
                print(transform.name + ": Never should've come here!");
            }
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }
}
