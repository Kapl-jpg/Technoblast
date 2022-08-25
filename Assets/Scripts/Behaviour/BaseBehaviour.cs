using UnityEngine;

public abstract class BaseBehaviour : MonoBehaviour, IBehaviour
{
    private void Awake()
    {
        if (TryGetComponent<IActor>(out var actor))
        {
            actor.AddBehaviour(this);
        }
    }

    public void UpdateBehaviour()
    {
        OnUpdate();
    }

    protected abstract void OnUpdate();
}