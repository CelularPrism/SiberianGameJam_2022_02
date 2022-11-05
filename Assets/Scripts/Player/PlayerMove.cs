using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Quaternion _playerRotation;
    [SerializeField] private float _playerSpeed;

    private Rigidbody _playerRigidbody;

    private PlayerMovement _inputActions;
    [SerializeField] private Vector3 _moveInput;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _inputActions = new PlayerMovement();

        _inputActions.Movement.Newaction.Enable();
    }
    private void Update()
    {
        _moveInput = transform.TransformDirection(_inputActions.Movement.Newaction.ReadValue<Vector3>());
    }
    private void FixedUpdate()
    {
        if(IsGrounded())
            _playerRigidbody.velocity = new Vector3(_moveInput.x * _playerSpeed, 0, _moveInput.z * _playerSpeed);
        else
            _playerRigidbody.velocity = new Vector3(_moveInput.x * _playerSpeed, -10.0f, _moveInput.z * _playerSpeed);
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1.2f);
    }
private void OnDisable()
    {
        _inputActions.Movement.Newaction.Disable();
    }
}
