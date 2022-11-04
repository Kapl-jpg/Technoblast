using System;
using UnityEngine;
using Zenject;

public class AnimationsEvents : MonoBehaviour
{
    [SerializeField] private MainCharacter mainCharacter;

    private SceneChanger _sceneChanger;

    private InputHandler _inputHandler;
    
    [Inject]
    private void Construct(SceneChanger sceneChanger,InputHandler inputHandler)
    {
        _sceneChanger = sceneChanger;
        _inputHandler = inputHandler;
    }

    public event Action OnLevelStartEvents; 
    public event Action OnLevelStartEndEvents; 
    public event Action OnWinGameEvents;
    public event Action OnDeathStartEvents;

    public void LevelStartEvents()
    {
        OnLevelStartEvents?.Invoke();
        StopCharacterMove();
    }

    public void LevelStartEndEvents()
    {
        OnLevelStartEndEvents?.Invoke();
        CharacterCanMove();
    }
    
    public void WinGameEvents()
    {
        OnWinGameEvents?.Invoke();
        StopCharacterMove();
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

    private void StopCharacterMove()
    {
        _inputHandler.StayCharacter = true;
    }

    private void CharacterCanMove()
    {
        _inputHandler.StayCharacter = false;
    }
}
