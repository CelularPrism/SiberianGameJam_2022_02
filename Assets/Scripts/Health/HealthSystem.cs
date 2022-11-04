using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IPlayerValue
{
    public bool isLive = true;

    [SerializeField] private GameObject death;
    [SerializeField] private float health;
    private IDeath _death;

    private void Start()
    {
        _death = death.GetComponent<IDeath>();
    }

    public void Damage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            health = 0;
            isLive = false;
            _death.Death();
        }
    }

    public float GetValue()
    {
        return health;
    }

    public void Death()
    {
        Damage(health);
    }
}
