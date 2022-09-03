using Interfaces;
using Player.Interactables;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] private bool _haveTimer;
    [SerializeField] private float _timeWhileObjectIsOpen;

    [Header("Reference on object"),Space(10)]
    [SerializeField] private OpenableActor _objectToOpen;
    
    public bool IsActive => true;

    public void Interact()
    {
        if (_haveTimer)
            OpenObjectByATime();
        else
            OpenObject();
    }

    private void OpenObject()
    {
        _objectToOpen.Open();
    }
    
    private void OpenObjectByATime()
    {
        _objectToOpen.OpenOnTime(_timeWhileObjectIsOpen);
    }
}
