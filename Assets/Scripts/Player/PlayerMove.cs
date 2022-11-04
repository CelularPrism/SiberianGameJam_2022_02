using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Quaternion _playerRotation;
    [SerializeField] private float _speed;

    private Transform _cameraTransform;

    private PlayerMovement _inputActions;
    private Vector3 _moveInput;

    private void OnEnable()
    {
        _inputActions = new PlayerMovement();

        _inputActions.Movement.Newaction.Enable();
    }
    private void Start()
    {
        _cameraTransform = this.gameObject.transform.GetChild(0);
    }
    private void Update()
    {
        _moveInput = _cameraTransform.forward * _inputActions.Movement.Newaction.ReadValue<Vector3>().y;
        _moveInput += _cameraTransform.right * _inputActions.Movement.Newaction.ReadValue<Vector3>().x;
        _moveInput.y = 0;

        transform.position += _moveInput * _speed * Time.deltaTime;

    }
    private void OnDisable()
    {
        _inputActions.Movement.Newaction.Disable();
    }
}
