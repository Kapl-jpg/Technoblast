using UnityEngine;

public class KillComponent : MonoBehaviour
{
    [SerializeField] private bool _ignoreInvincibility = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICanDie>(out var body))
        {
            if(_ignoreInvincibility)
                body.Death();
            else if(body.PossibleToDie)
                body.Death();
        }
    }
}
