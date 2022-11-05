using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private NavMeshAgent _navMesh;

        private void Start()
        {
            _navMesh = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            _navMesh.SetDestination(player.position);
        }
    }
}