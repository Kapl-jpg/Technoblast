using UnityEngine;
using Zenject;

public class ExitFinalScoreScene : MonoBehaviour
{
    [SerializeField] private int indexMainHubText;
    
    private SceneChanger _sceneChanger;

    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
    }

    private void Update()
    {
        if(Input.anyKey)
            _sceneChanger.LoadSceneIndexNumber(indexMainHubText);
    }
}
