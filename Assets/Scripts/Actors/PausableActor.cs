using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

public abstract class PausableActor : MonoBehaviour, IActor, ICanBePaused
{
    public List<IBehaviour> Behaviours { get; private set; } = new List<IBehaviour>();
    
    protected bool _isPaused;
    
    public bool IsPaused => _isPaused;
    
    protected abstract void Init();

    protected event Action OnPauseEvent;
    protected event Action OnUnpauseEvent;
    

    [Inject]
    private void Construct(IPauseDirector pauseDirector)
    {
        pauseDirector.RegisterICanBePausedActor(this);
    }
    
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
        SetPauseState(true);
        OnPauseEvent?.Invoke();
    }

    public void Unpause()
    {
        SetPauseState(false);
        OnUnpauseEvent?.Invoke();
    }

    private void SetPauseState(bool state)
    {
        _isPaused = state;
    }
    
    public bool AddBehaviour(IBehaviour behaviour)
    {
        if (Behaviours.Contains(behaviour))
            return false;
        
        Behaviours.Add(behaviour);
        return true;
    }
}
