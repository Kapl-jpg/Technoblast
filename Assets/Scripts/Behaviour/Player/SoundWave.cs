using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class SoundWave : BaseBehaviour
{
    [Header("Ray settings")] [Space(3)] [SerializeField]
    private float rayUpDistance;

    [SerializeField] private float rayDownDistance;
    [SerializeField] private float rayLeftDistance;
    [SerializeField] private float rayRightDistance;

    [Space(15)] [SerializeField] private Transform startPoint;
    [Range(-1, 1)] [SerializeField] private float angle;

    [Header("Draw in scene")] [Space(3)] [SerializeField]
    private bool drawRays = true;

    private float _currentDistance;

    private LaunchWaveVisual _launchWaveVisual;
    private InputHandler _playerInput;
    private Rigidbody _currentRigidbody;
    [SerializeField] private Vector3 boxSize;

    [SerializeField] private BoxCollider rightBoxCollider;
    [SerializeField] private BoxCollider leftBoxCollider;
    [SerializeField] private BoxCollider upBoxCollider;
    [SerializeField] private BoxCollider downBoxCollider;

    public event Action<JumpableObjectData> JumpableObjectHitEvent;
    public event Action JumpableObjectMissEvent;

    public bool stayOnPlatform { get; set; }

    public Collider Collider { get; set; }

    public Vector3 forceDirection { get; set; }
    private void Start()
    {
        SetSizeBoxCollider();
        SetPositionBoxCollider(Vector3.right);
        SetPositionBoxCollider(Vector3.left);
        SetPositionBoxCollider(Vector3.up);
        SetPositionBoxCollider(Vector3.down);
        
        _playerInput = GetComponent<InputHandler>();
        _currentRigidbody = GetComponent<Rigidbody>();
        _launchWaveVisual = GetComponent<LaunchWaveVisual>();
    }

    private void SetSizeBoxCollider()
    {
        rightBoxCollider.size = boxSize;
        leftBoxCollider.size = boxSize;
        upBoxCollider.size = boxSize;
        downBoxCollider.size = boxSize;
    }

    private void SetPositionBoxCollider(Vector3 direction)
    {
        CurrentBoxCollider(direction).gameObject.transform.position = CurrentRay(direction).direction * (GetDistance(direction) / 2);
        SetBoxColliderRotation(direction);
    }

    private void SetBoxColliderRotation(Vector3 direction)
    {
        CurrentBoxCollider(direction).gameObject.transform.LookAt(CurrentRay(direction).direction);
    }
    
    private Collider CurrentBoxCollider(Vector3 direction)
    {
        return direction switch
        {
            var v when v.Equals(Vector3.down) => downBoxCollider,
            var v when v.Equals(Vector3.up) => upBoxCollider,
            var v when v.Equals(Vector3.left) => leftBoxCollider,
            var v when v.Equals(Vector3.right) => rightBoxCollider,
            _ => null
        };
    }

    protected override void OnUpdate()
    {
        Flight(_playerInput.Fire);
    }

    private void Flight(Vector3 direction)
    {
        if (direction == Vector3.zero) 
            return;

        Collider = CurrentBoxCollider(direction).GetComponent<CollidersHit>().GetCollider();
        
        if (stayOnPlatform && Collider.TryGetComponent<IJumpableObject>(out var objectData))
        {
            JumpableObjectHitEvent?.Invoke(objectData.GetData());
            AddForce(GetForceDirection(direction), objectData.GetData().ObjectForce);
        }
        else
        {
            JumpableObjectMissEvent?.Invoke();
        }

        _launchWaveVisual.Launch(CurrentRay(direction).direction);
    }

    private Vector3 GetForceDirection(Vector3 direction)
    {
        var position = transform.position;
        return direction switch
        {
            var v when v.Equals(Vector3.down) => (position - downBoxCollider.transform.position).normalized,
            var v when v.Equals(Vector3.up) => (position - upBoxCollider.transform.position).normalized,
            var v when v.Equals(Vector3.left) => (position - leftBoxCollider.transform.position).normalized,
            var v when v.Equals(Vector3.right) => (position - rightBoxCollider.transform.position).normalized,
            _ => Vector3.zero
        };
    }

    private void AddForce(Vector3 direction, float forceValue)
    {
        if (forceValue == 0)
            return;

        _currentRigidbody.velocity =
            direction.x != 0 ? new Vector3(0, 0) : new Vector3(_currentRigidbody.velocity.x, 0);
        _currentRigidbody.AddForce(direction * forceValue, ForceMode.Impulse);
    }

    private float GetDistance(Vector3 direction)
    {
        return direction switch
        {
            var v when v.Equals(Vector3.down) => rayDownDistance,
            var v when v.Equals(Vector3.up) => rayUpDistance,
            var v when v.Equals(Vector3.left) => rayLeftDistance,
            var v when v.Equals(Vector3.right) => rayRightDistance,
            _ => 0
        };
    }

    #region Get rays

    private Ray CurrentRay(Vector3 direction)
    {
        switch (direction)
        {
            case var v when v.Equals(Vector3.down):
                _currentDistance = rayDownDistance;
                return DownRay();
            case var v when v.Equals(Vector3.up):
                _currentDistance = rayUpDistance;
                return UpRay();
            case var v when v.Equals(Vector3.left):
                _currentDistance = rayLeftDistance;
                return LeftRay();
            case var v when v.Equals(Vector3.right):
                _currentDistance = rayRightDistance;
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