using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroPhysicsController : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private HeroInputController _input;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private bool _isGrounded;

    public UnityAction IsGroundedValueChanged;

    public float AirSpeed => _rigidbody.velocity.y;

    public bool IsGrounded
    {
        get => _isGrounded;
        private set
        {
            if (_isGrounded == value)
            {
                return;
            }

            _isGrounded = value;
            IsGroundedValueChanged.Invoke();
        }
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    

    private void FixedUpdate()
    {
        _rigidbody.velocity = (new Vector2(_input.HAxisValue * _speed, _rigidbody.velocity.y));

        if (_input.IsJumpPressed && IsGrounded)
        {
            _rigidbody.velocity = (new Vector2(_rigidbody.velocity.x, _jumpHeight));
           
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }
}
