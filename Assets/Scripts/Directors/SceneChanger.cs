using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;

namespace Directors
{
    public class SceneChanger : MonoBehaviour
    {
        public int IndexScene { get; set; }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadLevelByIndex()
        {
            SceneManager.LoadScene(IndexScene);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}