using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private BoxCollider _playerBoxCollider;
    [SerializeField] private PlayerCollision _collision;

    [Space]
    [Header("Checks")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool isJumping = false;

    [Space]
    [Header("Speed Values")]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _speedModifier = 1f;
    [SerializeField] private float _slowModifier = 1f;
    [SerializeField] private float _minSpeed = 1f;
    [SerializeField] private float _maxSpeed = 1f;

    [Space]
    [Header("Jump Values")]
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collision = GetComponent<PlayerCollision>();
        _playerBoxCollider = GetComponent<BoxCollider>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (_collision.onGround)
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }

        if (canMove)
        {
            _speed += Time.deltaTime / 40;
            _speed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);

            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 4 * _speed / _slowModifier * _speedModifier;
        }
    }

    private void Jump(Vector3 dir)
    {
        _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0, 0);
        _rigidBody.velocity += dir * _jumpForce;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0, 0);
            Jump(Vector3.up);
        }
    }
}