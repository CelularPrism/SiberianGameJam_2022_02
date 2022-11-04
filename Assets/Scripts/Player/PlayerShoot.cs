using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("ShootSettings")]
    [SerializeField] private Vector3 _aimCenter = new Vector3(0.5f, 0.5f, 0f);
    [SerializeField] private Transform _gunEnd;
    [SerializeField] private int _shootDistance = 100;

    [Header("Camera")]
    [SerializeField] private Camera _mainCamera;

    private PlayerActions _playerActions;
    private void OnEnable()
    {
        _playerActions = new PlayerActions();
        _playerActions.Actions.Shoot.Enable();
        _playerActions.Actions.Shoot.performed += context => Shoot();
    }

    private void Shoot()
    {
        Debug.Log("Shoot!");
        RaycastHit hitInformation;

        Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(_aimCenter);

        if (Physics.Raycast(rayOrigin, _mainCamera.transform.forward, out hitInformation, _shootDistance))
        {
            ITarget target = hitInformation.transform.GetComponent<ITarget>();
            if(target != null)
                target.ApplyDamage();
        }
    }
    private void OnDisable()
    {
        _playerActions.Actions.Shoot.Disable();
    }
}
