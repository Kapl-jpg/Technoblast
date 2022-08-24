using UnityEngine;

public class PlatformForce : MonoBehaviour
{
    [SerializeField] private float force;
    
    public float GetForce()
    {
        return force;
    }
}
