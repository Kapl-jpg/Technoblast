using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(InputHandler))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Speed")] [SerializeField] private float timeToMaximumSpeed;

    [SerializeField] private float maxSpeed = 7;

    [SerializeField] private float forceJump;

    [SerializeField] private float airAcceleration = 0.875f;

    [SerializeField] private bool drawDistanceBeforeGround = true;

    [SerializeField] private float distanceToGround;

    private int _directionAxisX;

    private float _currentTimeAcceleration;

    private Rigidbody _currentRigidbody;

    private InputHandler _playerInput;

    private AnimationState _animationState;


    public bool StopCharacter { get; set; } = false;

    private void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _currentRigidbody = GetComponent<Rigidbody>();
        _animationState = GetComponent<AnimationState>();
    }

    private void Update()
    {
        HandleJump();
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        _currentRigidbody.useGravity = !_playerInput.StayCharacter && !_playerInput.Death;

        if (!_playerInput.Death && !_playerInput.StayCharacter)
        {
            HandleCharacterMovement();
        }
        else
        {
            _currentRigidbody.velocity = new Vector3(0,0,0);
        }
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
            
            _currentTimeAcceleration = 0;
        }
    }

    private void HandleAnimation()
    {
        _animationState.SetSpeedX(Mathf.Abs(_currentRigidbody.velocity.x));
        _animationState.SetSpeedY(_currentRigidbody.velocity.y);
        _animationState.SetGrounded(_playerInput.IsGrounded);
        if(!_animationState.GetWaveSide())
            _animationState.SetDirection(SetDirectionX());
        _animationState.SetFallSpeedX(_currentRigidbody.velocity.x);
        _animationState.CheckWaves();
    }

    private int SetDirectionX()
    {
            if (_currentRigidbody.velocity.x > 0)
                _directionAxisX = 1;
            if (_currentRigidbody.velocity.x < 0)
                _directionAxisX = -1;
            return _directionAxisX;
    }

    private void Run(Vector3 direction)
    {
        AccelerationTime();

        var velocity = _currentRigidbody.velocity;
        velocity +=
            new Vector3(
                Mathf.Clamp(CalculateAcceleration() * _currentTimeAcceleration * direction.x, -maxSpeed, maxSpeed) -
                velocity.x, 0);
        _currentRigidbody.velocity = velocity;
    }

    private void SlowingDown()
    {
        _currentRigidbody.velocity = new Vector3(0, _currentRigidbody.velocity.y);
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
        _currentTimeAcceleration += Time.fixedDeltaTime;
    }
}