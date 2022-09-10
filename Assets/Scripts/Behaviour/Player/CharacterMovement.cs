using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(InputHandler))]
public class CharacterMovement : BaseBehaviour
{
    [Header("Speed")] [SerializeField] private float timeToMaximumSpeed;

    [SerializeField] private float maxSpeed = 7;

    [SerializeField] private float timeToStop;

    [SerializeField] private float forceJump;

    [SerializeField] private float airAcceleration = 0.875f;

    [SerializeField] private bool drawDistanceBeforeGround = true;

    [SerializeField] private float distanceToGround;

    private int _directionAxisX;

    private float _currentTimeAcceleration;
    private float _currentTimeDeceleration;

    private Rigidbody _currentRigidbody;

    private InputHandler _playerInput;

    private AnimationState _animationState;

    private RotateCharacter _rotateCharacter;

    private float _speedDuringPressing;

    private void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _currentRigidbody = GetComponent<Rigidbody>();
        _animationState = GetComponent<AnimationState>();
        _rotateCharacter = GetComponent<RotateCharacter>();
    }

    protected override void OnUpdate()
    {
        HandleCharacterMovement();
        HandleJump();
        HandleAnimation();
    }

    private void HandleCharacterMovement()
    {
        if (_playerInput.Movement != 0)
        {
            SetDirectionX();
            SetRotate(_directionAxisX);
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

    private void HandleAnimation()
    {
        _animationState.SetSpeedX(Mathf.Abs(_currentRigidbody.velocity.x));
        _animationState.SetSpeedY(_currentRigidbody.velocity.y);
        _animationState.SetGrounded(_playerInput.IsGrounded);
        _animationState.SetDirection(SetDirectionX());
    }

    private int SetDirectionX()
    {
            if (_playerInput.Movement > 0)
                _directionAxisX = 1;
            if (_playerInput.Movement < 0)
                _directionAxisX = -1;
            return _directionAxisX;
    }

    private void SetRotate(int directionX)
    {
        _rotateCharacter.SetRotate(directionX);
    }

    private void Run(Vector3 direction)
    {
        AccelerationTime();

        _currentRigidbody.velocity +=
            new Vector3(
                Mathf.Clamp(CalculateAcceleration() * _currentTimeAcceleration * direction.x, -maxSpeed, maxSpeed) -
                _currentRigidbody.velocity.x, 0);
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
        _currentRigidbody.AddForce(direction * airAcceleration);
    }

    private bool CharacterIsJumped()
    {
        return _playerInput.Jump && _playerInput.IsGrounded;
    }

    private void HandleJump()
    {
        if (CharacterIsJumped())
        {
            _currentRigidbody.velocity = new Vector3(_currentRigidbody.velocity.x, forceJump);
        }
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