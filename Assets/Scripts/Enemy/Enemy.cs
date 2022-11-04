using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour, ITarget
{
    [Header("Materials of Enemy")]
    [SerializeField] private Material _enemyDeadMaterial;
    [SerializeField] private Material _enemyDefaultMaterial;

    private MeshRenderer _enemyRender;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _enemyRender = GetComponent<MeshRenderer>();
        _healthSystem = GetComponent<HealthSystem>();

        if (_enemyRender != null)
            _enemyRender.material = _enemyDefaultMaterial;
    }
    public void ApplyDamage()
    {
        _healthSystem.Death();
        if (_enemyRender != null)
            _enemyRender.material = _enemyDeadMaterial;
    }
}
