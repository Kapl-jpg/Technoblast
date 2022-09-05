using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameTimer : MonoBehaviour, ICanBePaused
{

    public bool IsPaused { get; private set; }
    
    public event Action <float> OnTimerTickEvent;

    private float _currentTimerValue;
    
    private void Update()
    {
        Tick();
    }

    private void Tick()
    {
        
    }
    
    public void Pause()
    {
        throw new NotImplementedException();
    }

    public void Unpause()
    {
        throw new NotImplementedException();
    }
}
