using UnityEngine.SceneManagement;

namespace Directors
{
    public class SceneLoader
    {
        public void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}