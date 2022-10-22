using System;
using Player;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private float distanceToGround;
    public float Movement { get; private set; }
    
    public Vector3 Fire { get; private set; }

    public bool Jump { get; private set; }

    public bool IsGrounded { get; private set; }
    public event Action OnLandedEvent;
    private float _airTime;
    
    public bool Trick { get; private set; }

    public bool Pause { get; private set; } = false;
    
    private void Update()
    {
        CheckInputStates();
    }

    private void CheckInputStates()
    {
        HandleMovementInput();
        CheckGrounded();
        CheckLanded();
        HandleJumpInput();
        HandleFireInput();
        HandleTrickInput();
        HandlePauseState();
    }
    
    private void HandleMovementInput()
    {
        Movement = Input.GetAxisRaw(GlobalAxis.HorizontalAxis);
    }

    private void CheckGrounded()
    {
        var ray = new Ray(transform.position, Vector3.down);
        IsGrounded = Physics.Raycast(ray, distanceToGround,groundLayer);
    }

    private void CheckLanded()
    {
        CheckLand();
        CheckAirTime();
    }
    
    private void CheckAirTime() 
    {
        if (IsGrounded)
        {
            _airTime = 0f;
        }
        else
        {
            _airTime += Time.deltaTime;
        }
    }
    private void CheckLand()
    {
        if (_airTime > 0)
        {
            if (IsGrounded)
            {
                OnLandedEvent?.Invoke();
            }
        }
    }
    
    
    private void HandleJumpInput()
    {
        Jump = Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space);
    }

    private void HandleFireInput()
    {
        if (!IsGrounded)
            Fire = GetFireDirection();
    }


    private Vector3 GetFireDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            return Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            return Vector3.right;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            return Vector3.down;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            return Vector3.up;
        
        return Vector3.zero;
    }

    private void HandleTrickInput()
    {
        if (!IsGrounded)
            Trick = Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.LeftShift);
    }

    private void HandlePauseState()
    {
        Pause = Input.GetKeyDown(KeyCode.Escape);
    }
}
