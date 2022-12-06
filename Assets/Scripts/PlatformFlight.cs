using UnityEngine;

public class PlatformFlight : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float waitTime;
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve curve;
    private Vector3 _upPoint;
    private Vector3 _downPoint;

    private float _waitTime;
    
    [SerializeField][Range(0,1)]
    private float offset = 0.5f;

    [SerializeField] private bool moveDown;
    [SerializeField] private bool waitStart;
    private void Start()
    {
        _upPoint = SetOffset(transform.position,amplitude);
        _downPoint = SetOffset(transform.position, -amplitude);
        
        if (waitStart)
        {
            _waitTime = 0;
        }
        else
        {
            _waitTime = waitTime;
        }
    }

    private void Update()
    {
        if (!Wait())
        {
            CountingTime();            
        }

        transform.position = Vector3.Lerp(_upPoint,_downPoint, curve.Evaluate(offset));
    }

    private bool Wait()
    {
        _waitTime += Time.deltaTime;
        if (_waitTime >= waitTime)
            return false;
        return true;
    }

    private static Vector3 SetOffset(Vector3 position, float offset)
    {
        return new Vector3(position.x, position.y + offset);
    }

    private void CountingTime()
    {
        
        if(moveDown)
            offset = Mathf.Clamp(offset + speed * Time.deltaTime,0,1);
        else
            offset = Mathf.Clamp(offset - speed * Time.deltaTime,0,1);
        
        if (offset >= 1)
        {
            moveDown = false;
            _waitTime = 0;
        }

        if (offset <= 0)
        {
            moveDown = true;
            _waitTime = 0;
        }
    }
}
