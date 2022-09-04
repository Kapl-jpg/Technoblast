using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    [Header("Animation Settings")] 
    [SerializeField] private float _delayBeforeStart = 0;
    [SerializeField] private float _loopDurationInSeconds;
    [SerializeField] private Vector3 _endValue;
    
    private void Start()
    {
        StartCoroutine(StartAsync());
    }

    private IEnumerator StartAsync()
    {
        yield return new WaitForSecondsRealtime(_delayBeforeStart);
        StartLoop();
    }

    private void StartLoop()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(_endValue, _loopDurationInSeconds));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}