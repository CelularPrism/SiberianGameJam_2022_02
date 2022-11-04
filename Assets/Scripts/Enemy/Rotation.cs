using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private Transform player;

        void Update()
        {
            transform.LookAt(player);
        }
    }
}