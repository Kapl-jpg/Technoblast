using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(InputHandler))]
public class CharacterMovement : BaseBehaviour
{
    [Header("Speed")] [SerializeField] private float timeToMaximumSpeed;
    [SerializeField] private float maxSpeed = 7;
    [SerializeField] private float timeToStop;

    [SerializeField] private float forceJump;

    [SerializeField] private float multiplierDecelerationInJump;

    [SerializeField] private bool drawDistanceBeforeGround = true;

    [SerializeField] private float distanceToGround;

    private float _currentTimeAcceleration;
    private float _currentTimeDeceleration;

    private Rigidbody _currentRigidbody;
    private InputHandler _playerInput;

    private float _speedDuringPressing;

    private void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _currentRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnUpdate()
    {
        HandleCharacterMovement();
        HandleJump();
    }

    private void HandleCharacterMovement()
    {
        if (_playerInput.Movement != 0)
        {
            if (_playerInput.IsGrounded)
                Run(new Vector3(_playerInput.Movement, 0));

            if (!_playerInput.IsGrounded)
                SlowingDownInAir(new Vector3(_playerInput.Movement, 0));
        }
        else
        {
            if (_playerInput.IsGrounded)
                SlowingDown();
        }
    }


    private void Run(Vector3 direction)
    {
        AccelerationTime();
        
        _currentRigidbody.velocity +=
            new Vector3(Mathf.Clamp(
                CalculateAcceleration() * _currentTimeAcceleration * direction.x, -maxSpeed,
                maxSpeed) - _currentRigidbody.velocity.x, 0);
    }


    private void SlowingDown()
    {
        DecelerationTime();
        if (_playerInput.IsGrounded)
            _currentRigidbody.velocity = Vector3.Lerp(_currentRigidbody.velocity,
                new Vector3(0, _currentRigidbody.velocity.y),
                (timeToStop - (timeToStop - _currentTimeDeceleration)) / timeToStop);
    }

    private void SlowingDownInAir(Vector3 direction)
    {
        _currentRigidbody.AddForce(direction * maxSpeed / SlowSpeed());
        _currentRigidbody.velocity = new Vector3(Mathf.Clamp(_currentRigidbody.velocity.x, -maxSpeed, maxSpeed),
            _currentRigidbody.velocity.y);
    }

    private float SlowSpeed()
    {
        return !_playerInput.IsGrounded ? multiplierDecelerationInJump : 1;
    }

    private void HandleJump()
    {
        if (_playerInput.Jump && _playerInput.IsGrounded)
            _currentRigidbody.velocity = new Vector3(_currentRigidbody.velocity.x, forceJump);
    }

    private void OnDrawGizmos()
    {
        if (!drawDistanceBeforeGround)
            return;
        var position = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, new Vector3(position.x, position.y - distanceToGround));
    }

    private float CalculateAcceleration()
    {
        return maxSpeed / timeToMaximumSpeed;
    }

    private void AccelerationTime()
    {
        _currentTimeDeceleration = 0;
        _currentTimeAcceleration += Time.deltaTime;
    }

    private void DecelerationTime()
    {
        _currentTimeAcceleration = 0;
        _currentTimeDeceleration += Time.deltaTime;
    }
}
