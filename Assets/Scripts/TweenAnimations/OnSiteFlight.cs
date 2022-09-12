using System;
using UnityEngine;
using DG.Tweening;

public class OnSiteFlight : MonoBehaviour
{
    [SerializeField] private float secondsFlight;
    [SerializeField] private float amplitude;
    
    private Vector3 _startPoint;
    private Sequence _sequence;
    
    private void Start()
    {
        _startPoint = transform.localPosition;
        transform.localPosition = EndPosition(Vector3.down);
        _sequence = DOTween.Sequence();
        FlightUpToDown(_sequence);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }

    private void FlightUpToDown(Sequence sequence)
    {
        sequence.Append(transform.DOLocalMove(EndPosition(Vector3.up), secondsFlight));
        sequence.Append(transform.DOLocalMove(EndPosition(Vector3.down), secondsFlight));
        sequence.SetLoops(-1, LoopType.Restart);
    }

    private Vector3 EndPosition(Vector3 direction)
    {
        return _startPoint + new Vector3(0,direction.y * amplitude,0);
    }
}
