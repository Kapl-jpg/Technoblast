using UnityEngine;

public class SoundWave : MonoBehaviour
{
    [SerializeField] private Rigidbody currentRigidbody;

    [Header("Ray settings")] [Space(3)]
    
    [SerializeField] private float rayUpDistance;
    [SerializeField] private float rayDownDistance;
    [SerializeField] private float rayLeftDistance;
    [SerializeField] private float rayRightDistance;
    [SerializeField] private float forceWave;
    [Range(-1, 1)] [SerializeField] private float angle;

    /// <summary>
    /// Удалить, если начало луча будет из центра персонажа
    /// </summary>
    [SerializeField] private Transform startPoint;

    [Header("Draw in scene")] [Space(3)]
    
    [SerializeField] private bool drawRays = true;

    private Ray _currentRay;
    private float _currentDistance;
    private Vector3 _hitPoint;

    public void Flight(Vector3 direction)
    {
        if(!Physics.Raycast(CurrentRay(direction), out var hit, _currentDistance))
            return;

        _hitPoint = hit.point;
        
        AddForce();
    }

    private Vector3 DirectionForce(Vector3 hitPoint)
    {
        return (transform.position - hitPoint).normalized;
    }

    private void AddForce()
    {
        currentRigidbody.velocity = new Vector3(currentRigidbody.velocity.x, 0);
        currentRigidbody.AddForce(DirectionForce(_hitPoint) * forceWave,ForceMode.Impulse);
    }

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

    #region Get rays

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

    private Ray CurrentRay(Vector3 direction)
    {
        switch (direction)
        {
            case var v when v.Equals(Vector3.down):
                _currentRay = DownRay();
                _currentDistance = rayDownDistance;
                break;
            case var v when v.Equals(Vector3.up):
                _currentRay = UpRay();
                _currentDistance = rayUpDistance;
                break;
            case var v when v.Equals(Vector3.left):
                _currentDistance = rayLeftDistance;
                _currentRay = LeftRay();
                break;
            case var v when v.Equals(Vector3.right):
                _currentRay = RightRay();
                _currentDistance = rayRightDistance;
                break;
        }

        return _currentRay;
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