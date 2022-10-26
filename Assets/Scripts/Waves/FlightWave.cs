using UnityEngine;

public class FlightWave : MonoBehaviour
{
    public float Speed { get; set; }
    public Vector3 Direction { get; set; }

    private void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }
}
