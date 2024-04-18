
using System;
using UnityEngine;
using UnityEngine.Events;
public class HeroInputController : MonoBehaviour
{
    private bool _isJumpPressed;
    private const string HorizontalAxisName = "Horizontal";
    private float _hAxisValue;

    [SerializeField] private HeroPhysicsController _physics;

    public HeroInputController(float hAxisValue)
    {
        HAxisValue = hAxisValue;
    }

    public float HAxisValue { get; private set; }
    public bool IsJumpPressed { get; private set; }


    private void Awake()
    {
        _physics.IsGroundedValueChanged += OnIsGroundedValueChanged;
    }

    private void Update()
    {
        if (Input.GetButtonDown(KeyCode.Space.ToString()) && _physics.IsGrounded)
        {
            IsJumpPressed = true;
        }
        
        _hAxisValue = Input.GetAxis(HorizontalAxisName);
    }

    private void OnDestroy()
    {
        _physics.IsGroundedValueChanged -= OnIsGroundedValueChanged;
    }

    private void OnIsGroundedValueChanged()
    {
        IsJumpPressed = false;
    }
}

