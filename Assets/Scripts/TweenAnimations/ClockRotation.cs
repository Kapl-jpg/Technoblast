using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    [Header("Animation Settings")] 
    [SerializeField] private float _delayBeforeStart = 0;
    [SerializeField] private float _loopDurationInSeconds;
    [SerializeField] private Vector3 _endValue;

    private Sequence _sequence;
    
    private void Start()
    {
        StartCoroutine(StartAsync());
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }

    private IEnumerator StartAsync()
    {
        yield return new WaitForSecondsRealtime(_delayBeforeStart);
        StartLoop();
    }

    private void StartLoop()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DORotate(_endValue, _loopDurationInSeconds));
        _sequence.SetLoops(-1, LoopType.Yoyo);   
    }
}