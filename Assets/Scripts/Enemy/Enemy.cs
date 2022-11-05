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
    [SerializeField] private float _maxDistanceToPlayer = 1.35f;

    private HealthSystem _enemyHealthSystem;
    private NavMeshAgent _enemyMeshAgent;
    private Animator _enemyAnimator;

    private float _enemySpeed;
    private float _enemyAnimWeight;

    private void Awake()
    {
        _enemyHealthSystem = GetComponent<HealthSystem>();
        _enemyMeshAgent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<Animator>();

        _enemySpeed = Random.Range(1.0f, 3.0f);
        _enemyAnimWeight = Mathf.Clamp(_enemySpeed, 1.0f, 2.0f);
    }
    private void Start()
    {
        if (_enemyMeshAgent != null)
        {
            WalkingToPlayer();
        }     
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
            _enemyAnimator.SetBool("isAttacking", true);
        }
        else
        {
            _enemyMeshAgent.isStopped = false;
            WalkingToPlayer();
        }
    }
    private void WalkingToPlayer()
    {
        //_enemyAnimator.SetBool("isAttacking", false);
        //_enemyAnimator.SetFloat("Speed", _enemyAnimWeight);

        _enemyMeshAgent.SetDestination(_player.transform.position);
        _enemyMeshAgent.speed = _enemySpeed;
    }
    public void ApplyDamage()
    {
        _enemyHealthSystem.Death();
    }
}
