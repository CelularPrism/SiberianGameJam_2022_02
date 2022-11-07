using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Speed of rotation")]
    [SerializeField] private float _cameraRotationSpeed;
    [SerializeField] private float _playerRotationSpeed;

    [SerializeField] private float _newXRotation;
    [SerializeField] private float _newYRotation;

    [SerializeField] private Vector3 _rotation;

    private PlayerActions _playerActions;
    private void OnEnable()
    {
        _playerActions = new PlayerActions();
        _playerActions.Actions.Rotation.Enable();
    }
    private void LateUpdate()
    {
        _rotation = new Vector3(_playerActions.Actions.Rotation.ReadValue<Vector2>().x, 
            _playerActions.Actions.Rotation.ReadValue<Vector2>().y, 0.0f);

        _newXRotation = (transform.rotation.eulerAngles.x - (_rotation.y * _cameraRotationSpeed * Time.deltaTime));

        if (_newXRotation < 280 && _newXRotation >= 180)
        {
            _newXRotation = 280;
        }
        else if (_newXRotation > 80 && _newXRotation < 180)
        {
            _newXRotation = 80;
        }

        _newYRotation = (transform.parent.rotation.eulerAngles.y + (_rotation.x * _playerRotationSpeed * Time.deltaTime));

        transform.rotation = Quaternion.Euler(_newXRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.x, _newYRotation, transform.parent.rotation.z);
    }
    private void OnDisable()
    {
        _playerActions.Actions.Rotation.Disable();
    }
}
