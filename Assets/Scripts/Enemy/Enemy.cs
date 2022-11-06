using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Enemies;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(EffectsManager))]
public class Enemy : MonoBehaviour, ITarget
{
    [Header("Player")]
    [SerializeField] private GameObject _player;

    [Header("Settings for movement")]
    [SerializeField] private float _maxDistanceToPlayer = 1.35f;

    private Vector3 _startPos;

    private EffectsManager _effectsManager;
    private HealthSystem _enemyHealthSystem;
    private NavMeshAgent _enemyMeshAgent;
    private Animator _enemyAnimator;
    private CapsuleCollider _enemyCollider;

    private float _enemySpeed;
    private float _enemyAnimWeight;
    private bool _isActive;

    private void Awake()
    {
        _enemyHealthSystem = GetComponent<HealthSystem>();
        _enemyMeshAgent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<Animator>();
        _enemyCollider = GetComponent<CapsuleCollider>();

        _enemySpeed = Random.Range(1.0f, 3.0f);
        _enemyAnimWeight = Mathf.Clamp(_enemySpeed, 0.0f, 1.0f);
    }
    private void Start()
    {
        if (_enemyMeshAgent != null)
        {
            _isActive = false;
            _startPos = transform.position;
            //_enemyMeshAgent.isStopped = true; //instead of CheckDistance(_startPos)(line 50)
            WalkingToPlayer(_player.transform.position);
        }
    }
    private void Update()
    {
        if (_enemyMeshAgent != null)
            if (_isActive)
                CheckDistance(_player.transform.position);
            else
                CheckDistance(_startPos); //can be remove if animation won't work
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

            if (_isActive)
            {
                _enemyAnimator.SetFloat("Speed", _enemyAnimWeight);
                _enemyAnimator.SetBool("isActive", _isActive);
            }
        }

        SetMovementPoint(position);
        _enemyMeshAgent.speed = _enemySpeed;
    }
    public void ApplyDamage()
    {
        if (_enemyAnimator != null)
            _enemyAnimator.SetTrigger("Dead");

        if (_enemyCollider != null)           //remove if there is problem
            _enemyCollider.enabled = false;

        if (_enemyMeshAgent != null)          //remove if there is problem
            _enemyMeshAgent.height = 0.1f;

        _enemyHealthSystem.Death();
        _effectsManager.Death();
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
