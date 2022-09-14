using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    public float Speed { get; set; }

    public Vector3 StartSize { get; set; }
    
    public Vector3 FinalSize { get; set; }

    public float MagnificationTime { get; set; }

    public float Angle { get; set; }

    private float _currentTime;

    private void Update()
    {
        ReSize();
        Rotate();
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(_currentTime * Angle,_currentTime * Angle , _currentTime * Angle);
    }

    private void ReSize()
    {
        transform.localScale = Vector3.Lerp(StartSize,FinalSize,MagnificationTime * _currentTime);
        TimerTick();
    }

    private void TimerTick()
    {
        _currentTime += Time.deltaTime;
    }
    
    private void OnBecameInvisible()
    {
        DisableCurrentObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        DisableCurrentObject();
    }

    private void DisableCurrentObject()
    {
        _currentTime = 0;
        transform.localScale = StartSize;
        gameObject.SetActive(false);
    }
}
