using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Transform[] targetPoints;
    [SerializeField] private float[] speed;
    [SerializeField] private bool loop;
    [SerializeField] private float waitTime;
    [SerializeField] private bool waitStart;
    [SerializeField] private AnimationCurve[] curve;

    private Transform _currentPoint;
    private Transform _currentTargetPoint;
    private float _currentSpeed;
    private AnimationCurve _currentAnimationCurve;

    private int _indexTarget;
    private float _offset;

    private bool _pong;
    private float _currentWaitTime;

    private void Start()
    {
        _indexTarget = 1;
        SetNextParameters(transform);
        if (waitStart)
        {
            _currentWaitTime = 0;
        }
        else
        {
            _currentWaitTime = waitTime;
        }

        transform.position = targetPoints[0].position;
    }

    private void Update()
    {
        SetNextTarget();
        Move();
    }

    private bool Wait()
    {
        _currentWaitTime += Time.deltaTime;
        if (_currentWaitTime >= waitTime)
            return false;
        return true;
    }

    private void Move()
    {
        if (Wait()) return;
        
        _offset += _currentSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(_currentPoint.position, _currentTargetPoint.position,
            _currentAnimationCurve.Evaluate(_offset*0.1f));
    }

    private void SetNextTarget()
    {
        if (_offset >= 1)
        {
            if (loop)
            {
                _indexTarget++;

                if (_indexTarget >= targetPoints.Length)
                {
                    _indexTarget = 0;
                }
            }
            else
            {
                if (_indexTarget >= targetPoints.Length - 1)
                {
                    _pong = true;
                }
                if (_indexTarget <= 0)
                {
                    _pong = false;
                }

                if (!_pong)
                    _indexTarget++;
                else
                    _indexTarget--;

            }

            SetNextParameters(transform);
        }
    }

    private void SetNextParameters(Transform currentTransform)
    {
        _currentPoint = currentTransform;
        _currentTargetPoint = targetPoints[_indexTarget];
        _currentAnimationCurve = curve[_indexTarget];
        _currentSpeed = speed[_indexTarget];
        _offset = 0;
        _currentWaitTime = 0;
    }
}
