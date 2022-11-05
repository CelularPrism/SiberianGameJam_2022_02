using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(BoxCollider))]
public class ActivateZone : MonoBehaviour
{
    [SerializeField] private int playerMask;
    [Header("Атрибут для указания, является ли триггер активатором или наоборот")]
    [SerializeField] private bool isActivator;

    [SerializeField] private Enemy[] enemies;
    [SerializeField] private PlayerShoot playerShoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerMask)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.SetActive(isActivator);
                }
            }
            playerShoot.SetActiveShoot(isActivator);
        }
    }
}
