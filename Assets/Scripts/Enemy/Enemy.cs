using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour, ITarget
{
    [Header("Player")]
    [SerializeField] private GameObject _player;

    [Header("Settings for movement")]
    [SerializeField] private float _maxDistanceToPlayer = 1.5f;

    private HealthSystem _enemyHealthSystem;
    private NavMeshAgent _enemyMeshAgent;

    private void Awake()
    {
        _enemyHealthSystem = GetComponent<HealthSystem>();
        _enemyMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        if (_enemyMeshAgent != null)
            _enemyMeshAgent.SetDestination(_player.transform.position);
    }
    private void Update()
    {
        if(_enemyMeshAgent != null)
            CheckDistance();
    }
    private void CheckDistance()
    {
        float distance = Vector3.Distance(_player.transform.position, this.transform.position);

        if (distance <= _maxDistanceToPlayer)
        {
            _enemyMeshAgent.isStopped = true;
        }
        else
        {
            _enemyMeshAgent.isStopped = false;
            _enemyMeshAgent.SetDestination(_player.transform.position);
        }
            
    }
    public void ApplyDamage()
    {
        _enemyHealthSystem.Death();
    }
}
