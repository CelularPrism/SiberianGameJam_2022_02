using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerMovement _inputActions;
    private Vector3 _moveInput;

    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new PlayerMovement();
        _inputActions.Movement.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _inputActions.Movement.Newaction.ReadValue<Vector3>();
        //_moveInput.z = _moveInput.y;
        _moveInput.y = 0;
        transform.position += _moveInput * speed * Time.deltaTime;
    }
}
