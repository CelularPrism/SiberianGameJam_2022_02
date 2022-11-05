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

    private Vector3 _startPos;

    private HealthSystem _enemyHealthSystem;
    private NavMeshAgent _enemyMeshAgent;
    private Animator _enemyAnimator;

    private float _enemySpeed;
    private float _enemyAnimWeight;
    private bool _isActive;

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
            WalkingToPlayer(_player.transform.position);
            _isActive = false;
            _startPos = transform.position;
        }
    }
    private void Update()
    {
        if (_enemyMeshAgent != null)
            if (_isActive)
                CheckDistance(_player.transform.position);
            else
                CheckDistance(_startPos);
    }
    private void CheckDistance(Vector3 position)
    {
        float distance = Vector3.Distance(position, this.transform.position);

        if (distance <= _maxDistanceToPlayer)
        {
            _enemyMeshAgent.isStopped = true;
            if (_isActive)
                _enemyAnimator.SetBool("isAttacking", true);
        }
        else
        {
            _enemyMeshAgent.isStopped = false;
            WalkingToPlayer(position);
        }
    }
    private void WalkingToPlayer(Vector3 position)
    {
        if (_enemyAnimator != null)
        {
            _enemyAnimator.SetBool("isAttacking", false);
            _enemyAnimator.SetFloat("Speed", _enemyAnimWeight);
        }

        SetMovementPoint(position);
        _enemyMeshAgent.speed = _enemySpeed;
    }
    public void ApplyDamage()
    {
        _enemyHealthSystem.Death();
    }

    public void SetMovementPoint(Vector3 point)
    {
        _enemyMeshAgent.SetDestination(point);
    }

    public void SetActive(bool value)
    {
        _isActive = value;
    }

    public bool GetActive()
    {
        return _isActive;
    }
}
