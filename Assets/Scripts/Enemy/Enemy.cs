using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour, ITarget
{
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }
    public void ApplyDamage()
    {
        _healthSystem.Death();
    }
}
