using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    public float Speed { get; set; }

    public Vector3 StartSize { get; set; }
    
    public Vector3 FinalSize { get; set; }

    public float MagnificationTime { get; set; }

    private float _currentTime;


    private void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void ReSize()
    {
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
        gameObject.SetActive(false);
    }
}
