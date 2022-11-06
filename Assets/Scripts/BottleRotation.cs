using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRotation : MonoBehaviour
{
    [Header("Speed of rotation(degrees)")]
    [SerializeField] private float _degreesPerSecond = 10;

    private void Update()
    {
        transform.Rotate(new Vector3(0, _degreesPerSecond, 0) * Time.deltaTime);
    }
}
