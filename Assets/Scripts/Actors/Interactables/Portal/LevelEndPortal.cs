using System;
using Interfaces;
using UnityEngine;

public class LevelEndPortal : MonoBehaviour, IInteractable, ILevelEnd
{
    [SerializeField] private bool _isActiveAtStart;
    public bool IsActive { get; private set; }
    public event Action OnLevelEndEvent;

    private void Start()
    {
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