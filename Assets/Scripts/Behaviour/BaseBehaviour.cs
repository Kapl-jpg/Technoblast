using UnityEngine;

public abstract class BaseBehaviour : MonoBehaviour, IBehaviour
{
    private void Awake()
    {
        if (TryGetComponent<IActor>(out var actor))
        {
            actor.AddBehaviour(this);
        }
        else
        {
            Debug.LogError("There is no IActor component on " + gameObject.name);
        }
    }

    public void UpdateBehaviour()
    {
        OnUpdate();
    }

    protected abstract void OnUpdate();
}