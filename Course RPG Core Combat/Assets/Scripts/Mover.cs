using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target = null;
    
    void Start()
    {
        
    }

    void Update()
    {
        NavMeshAgent _playerNavMeshAgent = GetComponent<NavMeshAgent>();
        _playerNavMeshAgent.destination = target.position;
    }
}
