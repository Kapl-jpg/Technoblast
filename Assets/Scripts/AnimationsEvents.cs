using System;
using UnityEngine;
using Zenject;

public class AnimationsEvents : MonoBehaviour
{
    [SerializeField] private MainCharacter mainCharacter;

    private SceneChanger _sceneChanger;

    private CharacterMovement _characterMovement;
    
    [Inject]
    private void Construct(SceneChanger sceneChanger,CharacterMovement characterMovement)
    {
        _sceneChanger = sceneChanger;
        _characterMovement = characterMovement;
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
        _characterMovement.StopCharacter = true;
    }

    private void CharacterCanMove()
    {
        _characterMovement.StopCharacter = false;
    }
}
