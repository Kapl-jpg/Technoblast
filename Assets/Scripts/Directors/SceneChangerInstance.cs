using UnityEngine;
using Zenject;

namespace Directors
{
    public class SceneChangerInstance : MonoBehaviour
    {
        private SceneChanger _instance;
        
        [Inject]
        private void Construct(SceneChanger sceneChanger)
        {
            _instance = sceneChanger;
        }

        public void RestartLevel()
        {
            _instance.RestartCurrentScene();
        }

        public void QuitGame()
        {
            _instance.QuitGame();
        }
    }
}