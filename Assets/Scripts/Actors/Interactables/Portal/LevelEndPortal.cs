using System;
using Directors;
using Interfaces;
using UnityEngine;
using Zenject;

public class LevelEndPortal : MonoBehaviour, IInteractable, ILevelEnd
{
    [SerializeField] private bool _isActiveAtStart;
    public bool IsActive { get; private set; }
    public event Action OnLevelEndEvent;

    private SceneChanger _sceneChanger;

    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
        IsActive = _isActiveAtStart;
    }
    
    public void Interact()
    {
        if (IsActive)
        {
            OnLevelEndEvent?.Invoke();
        }
    }
}