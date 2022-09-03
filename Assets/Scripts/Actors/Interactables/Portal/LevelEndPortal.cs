using Directors;
using Interfaces;
using UnityEngine;
using Zenject;

public class LevelEndPortal : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isActiveAtStart;
    public bool IsActive { get; private set; }

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
            _sceneChanger.LoadNextScene();
        }
    }
}