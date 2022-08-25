using UnityEngine;

public class KillComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ICanDie>(out var body))
            body.Death();
    }
}
