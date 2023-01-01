using UnityEngine;
using DG.Tweening;

public class OnSiteFlight : MonoBehaviour
{
    [SerializeField] private float secondsFlight;
    [SerializeField] private float amplitude;
    [SerializeField] private float maxOffsetTime = 0.2f;

    private Vector3 _startPoint;
    private Sequence _sequence;

    private void Start()
    {
        
        _sequence = DOTween.Sequence();
        FlightUpToDown(_sequence);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }

    private void FlightUpToDown(Sequence sequence)
    {
        var rand = Random.Range(0, 2);
        if (rand == 0)
        {
            _startPoint = transform.localPosition;
            transform.localPosition = EndPosition(Vector3.down);
            sequence.Append(transform.DOLocalMove(EndPosition(Vector3.up), secondsFlight + Random.Range(-maxOffsetTime,maxOffsetTime)));
            sequence.Append(transform.DOLocalMove(EndPosition(Vector3.down), secondsFlight+ Random.Range(-maxOffsetTime,maxOffsetTime)));
        }
        else
        {
            _startPoint = transform.localPosition;
            transform.localPosition = EndPosition(Vector3.up);
            sequence.Append(transform.DOLocalMove(EndPosition(Vector3.down), secondsFlight+ Random.Range(-maxOffsetTime,maxOffsetTime)));
            sequence.Append(transform.DOLocalMove(EndPosition(Vector3.up), secondsFlight+ Random.Range(-maxOffsetTime,maxOffsetTime)));
        }

        sequence.SetLoops(-1, LoopType.Restart);
    }

    private Vector3 EndPosition(Vector3 direction)
    {
        return _startPoint + new Vector3(0, direction.y * amplitude, 0);
    }
}
