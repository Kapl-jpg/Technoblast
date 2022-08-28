using Player;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float distanceToGround;
    public float Movement { get; private set; }
    
    public Vector3 Fire { get; private set; }

    public bool MovementIsPressed { get; private set; }

    public bool Jump { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Update()
    {
        HandleMovementInput();
        CheckGrounded();
        HandleJumpInput();
        HandleFireInput();
    }

    private void HandleMovementInput()
    {
        Movement = Input.GetAxisRaw(GlobalAxis.HorizontalAxis);
        MovementIsPressed = Input.GetKey(KeyCode.D);
    }
    
    private void CheckGrounded()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
    
    private void HandleJumpInput()
    {
        Jump = Input.GetKeyDown(KeyCode.W);
    }
    
    private void HandleFireInput()
    {
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
}
