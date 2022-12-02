using Directors;
using UnityEngine;
using Zenject;

public class ExitFinalScoreScene : MonoBehaviour
{
    [SerializeField] private int indexMainHubText;
    [SerializeField] private StatSaver statSaver;
    private SceneChanger _sceneChanger;

    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
    }

    private void Update()
    {
        if (!Input.anyKey) return;
        _sceneChanger.LoadSceneIndexNumber(indexMainHubText);
        statSaver.ClearLevelStateData();
    }
}
