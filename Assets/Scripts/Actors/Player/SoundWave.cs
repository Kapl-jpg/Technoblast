using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class SoundWave : BaseBehaviour
{
    [Header("Ray settings")] [Space(3)]
    [SerializeField] private float rayUpDistance;
    [SerializeField] private float rayDownDistance;
    [SerializeField] private float rayLeftDistance;
    [SerializeField] private float rayRightDistance;
    
    [Space(15)]
    [SerializeField] private Transform startPoint;
    [Range(-1, 1)] [SerializeField] private float angle;

    [Header("Draw in scene")] [Space(3)]
    [SerializeField] private bool drawRays = true;
    
    private float _currentDistance;

    private InputHandler _playerInput;
    private Rigidbody _currentRigidbody;
    
    private void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _currentRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnUpdate()
    {
        Flight(_playerInput.Fire);
    }

    private void Flight(Vector3 direction)
    {
        if (direction != Vector3.zero && Physics.Raycast(CurrentRay(direction), out var hit, _currentDistance) )
        {
            if (hit.collider.TryGetComponent<IHaveJumpForce>(out var jumpForce))
            {
                AddForce(GetForceDirection(hit.point), jumpForce.GetForce());
            }
        }
    }
    
    private Vector3 GetForceDirection(Vector3 hitPoint)
    {
        return (transform.position - hitPoint).normalized;
    }
    
    private void AddForce(Vector3 direction,float forceValue)
    {
        _currentRigidbody.velocity = new Vector3(_currentRigidbody.velocity.x, 0);
        _currentRigidbody.AddForce(direction * forceValue, ForceMode.Impulse);
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
        
        return new Ray(Vector3.zero,Vector3.zero);
    }
    
    private Ray RightRay()
    {
        return new Ray(startPoint.position,  new Vector3(CosValue(), SinValue()));
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