using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Quaternion _playerRotation;

    private PlayerMovement _inputActions;
    private Vector3 _moveInput;

    private void OnEnable()
    {
        _inputActions = new PlayerMovement();

        _inputActions.Movement.Newaction.Enable();
    }

    private void Update()
    {
        _moveInput = new Vector3(_inputActions.Movement.Newaction.ReadValue<Vector3>().x, 0.0f,
            _inputActions.Movement.Newaction.ReadValue<Vector3>().y);

        transform.position += _moveInput * _speed * Time.deltaTime;

    }
    private void OnDisable()
    {
        _inputActions.Movement.Newaction.Disable();
    }
}
