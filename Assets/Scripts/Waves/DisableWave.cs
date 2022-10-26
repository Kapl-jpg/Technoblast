using UnityEngine;

public class DisableWave : MonoBehaviour
{
    public float DisableTime { get; set; }

    private float _currentTime;

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void ResetTime()
    {
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= DisableTime)
        {
            gameObject.SetActive(false);
        }
    }
}
