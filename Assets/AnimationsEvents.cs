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
    
    public void StartDeathEvents()
    {
        _mainCharacter.StartDeathEvents();
    }

    public void LoadNextScene()
    {
        _sceneChanger.LoadNextScene();
    }
}
