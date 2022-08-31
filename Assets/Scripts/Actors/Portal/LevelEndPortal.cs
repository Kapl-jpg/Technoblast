using Directors;
using Interfaces;
using UnityEngine;
using Zenject;

public class LevelEndPortal : MonoBehaviour, IInteractable
{
    public bool IsActive { get; private set; }

    private SceneChanger _sceneChanger;

    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
        IsActive = true;
    }
    
    public void Interact()
    {
        if (IsActive)
        {
            _sceneChanger.LoadNextScene();
        }
    }
}