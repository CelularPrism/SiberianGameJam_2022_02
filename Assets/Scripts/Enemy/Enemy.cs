using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITarget
{
    [Header("Materials of Enemy")]
    [SerializeField] private Material _enemyDeadMaterial;
    [SerializeField] private Material _enemyDefaultMaterial;

    private MeshRenderer _enemyRender;

    private void Awake()
    {
        _enemyRender = GetComponent<MeshRenderer>();

        if (_enemyRender != null)
            _enemyRender.material = _enemyDefaultMaterial;
    }
    public void ApplyDamage()
    {
        Debug.Log("Damage!");
        if (_enemyRender != null)
            _enemyRender.material = _enemyDeadMaterial;
    }
}
