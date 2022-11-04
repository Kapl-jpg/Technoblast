using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class SoundWave : MonoBehaviour
{
    [Header("Ray settings")]
    [Space(3)]

    [SerializeField] private float rayUpDistance;
    [SerializeField] private float rayDownDistance;
    [SerializeField] private float rayLeftDistance;
    [SerializeField] private float rayRightDistance;

    [Header("Sphere collider")]

    [SerializeField]
    private float sphereRadius = 0.4f;

    [Space(15)][SerializeField] private Transform startPoint;
    [Range(-1, 1)][SerializeField] private float angle;

    [SerializeField]
    private float fireCooldown;

    [SerializeField] private Color missWaveColor;

    [Header("Draw in scene")]
    [Space(3)]
    [SerializeField]
    private bool drawRays = true;

    private LaunchWaveVisual _launchWaveVisual;
    private InputHandler _playerInput;
    private Rigidbody _currentRigidbody;
    private AnimationState _animationState;

    public event Action<JumpableObjectData> JumpableObjectHitEvent;
    public event Action JumpableObjectMissEvent;

    private float _currentTime;

    #region Initialize the initial data and install the box collider

    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        _animationState = GetComponent<AnimationState>();
        _playerInput = GetComponent<InputHandler>();
        _currentRigidbody = GetComponent<Rigidbody>();
        _launchWaveVisual = GetComponent<LaunchWaveVisual>();
    }

    private float SphereDistance(Vector3 direction)
    {
        switch (direction)
        {
            case var v when v.Equals(Vector3.up):
                return rayUpDistance;
            case var v when v.Equals(Vector3.down):
                return rayDownDistance;
            case var v when v.Equals(Vector3.left):
                return rayLeftDistance;
            case var v when v.Equals(Vector3.right):
                return rayRightDistance;
        }
        return 0;
    }

    #endregion

    #region Launching a wave

    private void Update()
    {
        CountingTime();
        Flight(_playerInput.Fire);        
    }

    public void Flight(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        if (_currentTime < fireCooldown)
            return;

        if (Physics.SphereCast(gameObject.transform.position, sphereRadius, CurrentRay(direction).direction, out var hit, SphereDistance(direction))&&
            hit.collider.TryGetComponent<IJumpableObject>(out var objectData))
        {
            objectData.GetData();
            JumpableObjectHitEvent?.Invoke(objectData.GetData());
            AddForce(GetForceDirection(direction), objectData.GetData().ObjectForce);
            _launchWaveVisual.Launch(CurrentRay(direction).direction, objectData.GetData().WaveColor);
        }
        else
        {
            JumpableObjectMissEvent?.Invoke();
            _launchWaveVisual.Launch(CurrentRay(direction).direction, missWaveColor);
        }

        _animationState.SetLaunchWave(direction, _playerInput.IsGrounded, _currentRigidbody.velocity.x);
        _currentTime = 0;
    }

    private void CountingTime()
    {
        _currentTime += Time.deltaTime;
    }

    private Vector3 GetForceDirection(Vector3 direction)
    {
        return (-CurrentRay(direction).direction).normalized;
    }

    private void AddForce(Vector3 direction, float forceValue)
    {
        if (forceValue == 0)
            return;

        _currentRigidbody.velocity =
            direction.x != 0 ? new Vector3(0, 0) : new Vector3(_currentRigidbody.velocity.x, 0);

        _currentRigidbody.AddForce(direction * forceValue, ForceMode.Impulse);
    }

    #endregion

    #region Get rays

    private Ray CurrentRay(Vector3 direction)
    {
        switch (direction)
        {
            case var v when v.Equals(Vector3.down):
                return DownRay();
            case var v when v.Equals(Vector3.up):
                return UpRay();
            case var v when v.Equals(Vector3.left):
                return LeftRay();
            case var v when v.Equals(Vector3.right):
                return RightRay();
        }

        return new Ray(Vector3.zero, Vector3.zero);
    }

    private Ray RightRay()
    {
        return new Ray(startPoint.position, new Vector3(CosValue(), SinValue()));
    }

    private Ray LeftRay()
    {
        return new Ray(startPoint.position, new Vector3(-CosValue(), SinValue()));
    }

    private Ray DownRay()
    {
        return new Ray(startPoint.position, Vector3.down);
    }

    private Ray UpRay()
    {
        return new Ray(startPoint.position, Vector3.up);
    }

    #endregion

    #region Calculate Cos and Sin angle

    private float CosValue()
    {
        return Mathf.Cos(angle);
    }

    private float SinValue()
    {
        return Mathf.Sin(angle);
    }

    #endregion

    #region Draw on scene

    private void OnDrawGizmos()
    {
        if (!drawRays)
            return;

        var position = startPoint.position;
        Debug.DrawRay(position, new Vector3(CosValue(), SinValue()) * rayRightDistance, Color.yellow);
        Debug.DrawRay(position, new Vector3(-CosValue(), SinValue()) * rayLeftDistance, Color.yellow);
        Debug.DrawRay(position, Vector3.down * rayDownDistance, Color.yellow);
        Debug.DrawRay(position, Vector3.up * rayUpDistance, Color.yellow);
    }

    #endregion
}