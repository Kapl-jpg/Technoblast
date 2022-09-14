using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    public float Speed { get; set; }

    public Vector3 StartSize { get; set; }
    
    public Vector3 FinalSize { get; set; }

    public float MagnificationTime { get; set; }



    private void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
