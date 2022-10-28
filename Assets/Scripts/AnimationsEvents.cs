using System;
using UnityEngine;
using Zenject;

public class AnimationsEvents : MonoBehaviour
{
    [SerializeField] private MainCharacter mainCharacter;

    private SceneChanger _sceneChanger;
    
    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
    }

    public event Action OnLevelStartEvents; 
    public event Action OnLevelStartEndEvents; 
    public event Action OnWinGameEvents;
    public event Action OnDeathStartEvents;

    public void LevelStartEvents()
    {
        OnLevelStartEvents?.Invoke();
    }

    public void LevelStartEndEvents()
    {
        OnLevelStartEndEvents?.Invoke();
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
        mainCharacter.StartDeathEvents();
    }

    public void LoadNextScene()
    {
        _sceneChanger.LoadNextScene();
    }
}
