using System;
using Directors;
using UnityEngine;
using Zenject;

public class AnimationsEvents : MonoBehaviour
{
    [SerializeField] private MainCharacter _mainCharacter;

    private SceneChanger _sceneChanger;
    
    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
    }

    public event Action OnLevelStartEvents; 
    public event Action OnWinGameEvents;
    public event Action OnDeathStartEvents;

    public void LevelStartEvents()
    {
        OnLevelStartEvents?.Invoke();
    }
    
    public void WinGameSoundEvents()
    {
        OnWinGameEvents?.Invoke();
    }
    
    public void DeathSoundEvents()
    {
        OnDeathStartEvents?.Invoke();
    }
    
    public void StartDeathEvents()
    {
        _mainCharacter.StartDeathEvents();
    }

    public void LoadNextScene()
    {
        _sceneChanger.LoadNextScene();
    }
}
