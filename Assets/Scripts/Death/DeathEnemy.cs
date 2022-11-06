using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemy : MonoBehaviour, IDeath
{
    public void Death()
    {
        Destroy(gameObject, 0.5f);
    }
}
