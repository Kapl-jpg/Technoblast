using System;
using Directors.UI;
using Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

public class GlobalGameTimer : MonoBehaviour, ICanBePaused
{
    [SerializeField] private TextMeshProUGUI _uiTimerText;

    public float CurrentTimerValue
    {
        get => _currentTimerValue;
        set => _currentTimerValue = value > 0 ? value : 0;
    }
    private float _currentTimerValue;

    public bool IsPaused { get; private set; }
    
    public event Action <int> OnTimerTickEvent;

    [Inject]
    private void Construct(IPauseDirector pauseDirector)
    {
        pauseDirector.RegisterICanBePausedActor(this);
        
        var uiUpdater = new UpdateTimerUI(_uiTimerText);
        OnTimerTickEvent += uiUpdater.UpdateUI;
    }

    private void Update()
    {
        Tick();
    }
    
    private void Tick()
    {
        if (!IsPaused)
        {
            _currentTimerValue += Time.deltaTime;
            OnTimerTickEvent?.Invoke(Mathf.RoundToInt(_currentTimerValue));   
        }
    }
    
    public void Pause()
    {
        SetPauseState(true);
    }

    public void Unpause()
    {
        SetPauseState(false);
    }

    private void SetPauseState(bool state)
    {
        IsPaused = state;
    }
}
