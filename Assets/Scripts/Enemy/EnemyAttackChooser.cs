using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackChooser : MonoBehaviour
{
    [Header("Attack Clips")]
    [SerializeField] private List<AnimatorOverrideController> _enemyAttack;

    private Animator _enemyAnimator;

    private void Awake()
    {
        int num = Random.Range(0, _enemyAttack.Count + 1);
        _enemyAnimator = GetComponent<Animator>();
        _enemyAnimator.runtimeAnimatorController = _enemyAttack[num];
    }
}
