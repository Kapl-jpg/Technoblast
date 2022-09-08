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
    
    private void HandleJumpInput()
    {
        Jump = Input.GetKeyDown(KeyCode.W);
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
            Trick = Input.GetKeyDown(KeyCode.S);
    }

    private void HandlePauseState()
    {
        Pause = Input.GetKeyDown(KeyCode.Escape);
    }
}
