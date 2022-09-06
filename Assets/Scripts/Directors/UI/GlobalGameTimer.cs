using System;
using Directors;
using Directors.UI;
using TMPro;
using UnityEngine;

public class GlobalGameTimer : SingleInstanceObject, ICanBePaused
{
    [SerializeField] private TextMeshProUGUI _uiTimerText;
    public bool IsPaused { get; private set; }
    
    public event Action <float> OnTimerTickEvent;

    private float _currentTimerValue;

    protected override void Init()
    {
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
            OnTimerTickEvent?.Invoke(_currentTimerValue);   
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
