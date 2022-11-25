using System;
using Interfaces;
using UnityEngine;
using Zenject;

public class LevelEndPortal : MonoBehaviour, IInteractable, ILevelEnd
{
    [SerializeField] private int indexNextScene;
    
    [SerializeField] private bool _isActiveAtStart;
    public bool IsActive { get; private set; }

    private MainCharacter _mainCharacter;
    private SceneChanger _sceneChanger;
    public event Action OnLevelEndEvent;

    [Inject]
    private void Construct(MainCharacter mainCharacter,SceneChanger sceneChanger)
    {
        _mainCharacter = mainCharacter;
        _sceneChanger = sceneChanger;
    }
    
    private void Start()
    {
        IsActive = _isActiveAtStart;
    }

    public void Interact()
    {
        if (IsActive)
        {
            _sceneChanger.IndexNextScene = indexNextScene;
            _mainCharacter.SetLevelEnd(gameObject.GetComponent<ILevelEnd>());
            OnLevelEndEvent?.Invoke();
        }
    }
}