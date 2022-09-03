using System.Collections.Generic;
using UnityEngine;

public abstract class PausableActor : MonoBehaviour, IActor, ICanBePaused
{
    public List<IBehaviour> Behaviours { get; private set; } = new List<IBehaviour>();
    
    protected bool _isPaused;
    
    public bool IsPaused => _isPaused;
    
    protected abstract void Init();
    
    private void Start()
    {
        Init();
    }
    
    protected virtual void Update()
    {
        if (!_isPaused)
        {
            foreach (var behaviour in Behaviours)
            {
                behaviour.UpdateBehaviour();
            }
        }
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }
    
    public bool AddBehaviour(IBehaviour behaviour)
    {
        if (Behaviours.Contains(behaviour))
            return false;
        
        Behaviours.Add(behaviour);
        return true;
    }
}
