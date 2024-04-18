using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
public class HeroAnimationController : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private HeroInputController _input;
    [SerializeField] private HeroPhysicsController _physics;
    [SerializeField] private SpriteRenderer _renderer;
    
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int AirSpeed = Animator.StringToHash("AirSpeed");
    private static readonly int IsRun = Animator.StringToHash("IsRun");
    private static readonly int Jump = Animator.StringToHash("Jump");


    private void Awake()
    {
        _physics.IsGroundedValueChanged += OnIsGroundedValueChanged;
        Camera.main.DOFieldOfView(90, 1.0f);
    }

    private void Update()
    {
        _animator.SetBool(IsRun, Mathf.Abs(_input.HAxisValue) > float.Epsilon);
        _renderer.flipX = _input.HAxisValue < 0.0f;

        if (_input.IsJumpPressed)
        {
            _animator.SetTrigger(Jump);
        }

    }

    private void OnDestroy()
    {
        _physics.IsGroundedValueChanged -= OnIsGroundedValueChanged;
    }

    private void OnIsGroundedValueChanged()
    {
        _animator.SetBool(IsGrounded, _physics.IsGrounded);
    }
}
