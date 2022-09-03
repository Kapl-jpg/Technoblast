using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    [Header("Animation Settings")] 
    [SerializeField] private float _delayBeforeStart = 0;
    [SerializeField] private float _loopDurationInSeconds;
    
    private void Start()
    {
        var endValue = new Quaternion(0,360,0,0);
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotateQuaternion(endValue, _loopDurationInSeconds));
        
        StartCoroutine(StartAsync(sequence));
    }

    private IEnumerator StartAsync(Sequence sequence)
    {
        yield return new WaitForSecondsRealtime(_delayBeforeStart);
        sequence.SetLoops(-1, LoopType.Restart);
    }
}