using System.Collections;
using UnityEngine;

public class OffObjectInTime : MonoBehaviour
{
    [SerializeField] private float _timeToOff = 0.5f;
    
    public void StartTimer()
    {
        StartCoroutine(StartTimerAsync());
    }

    private IEnumerator StartTimerAsync()
    {
        yield return new WaitForSecondsRealtime(_timeToOff);
        gameObject.SetActive(false);
    }
}
