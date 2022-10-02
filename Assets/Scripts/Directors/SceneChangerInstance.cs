using UnityEngine;
using Zenject;

namespace Directors
{
    public class SceneChangerInstance : MonoBehaviour
    {
        private SceneChanger _instance;
        private WriteInFile _writeInFile;
        
        [Inject]
        private void Construct(SceneChanger sceneChanger,WriteInFile writeInFile)
        {
            _writeInFile = writeInFile;
            _instance = sceneChanger;
        }

        public void RestartLevel()
        {
            _instance.RestartCurrentScene();
        }

        public void LoadNextScene()
        {
            _instance.LoadNextScene();
        }

        public void LoadMainMenuScene()
        {
            _instance.LoadMainMenuScene();
        }
        
        public void QuitGame()
        {
            _instance.QuitGame();
        }
    }
}