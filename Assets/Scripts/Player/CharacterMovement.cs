using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(GetInput))]

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    
    [Tooltip("Drawn on scene")]
    [SerializeField] private bool drawDistanceBeforeGround = true;
    [SerializeField] private float distanceToGround;

    private Rigidbody _currentRigidbody;
    private GetInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<GetInput>();
        _currentRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleCharacterMovement();
        HandleJump();
    }

    private void HandleCharacterMovement()
    {
        if(_playerInput.Movement != 0)
            Run(new Vector3(_playerInput.Movement,transform.position.y));
    }
    
    private void Run(Vector3 direction)
    {
        _currentRigidbody.AddForce(direction * speed, ForceMode.Force);
        _currentRigidbody.velocity = new Vector3(Mathf.Clamp(_currentRigidbody.velocity.x, -speed, speed),
            _currentRigidbody.velocity.y);
    }

    private void HandleJump()
    {
        if(_playerInput.Jump && _playerInput.IsGrounded)
            _currentRigidbody.velocity = new Vector3(_currentRigidbody.velocity.x,forceJump);
    }

    private void OnDrawGizmos()
    {
        if(!drawDistanceBeforeGround)
            return;
        var position = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, new Vector3(position.x,position.y - distanceToGround));
    }
}
