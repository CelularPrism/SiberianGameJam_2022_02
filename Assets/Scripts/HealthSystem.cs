using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public bool isLive = true;

    [SerializeField] private float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            health = 0;
            isLive = false;
        }
    }
}
