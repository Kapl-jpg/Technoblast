using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;
using Zenject;

public class SceneChanger : MonoBehaviour
{
    private WriteInFile _writeInFile;

    [Inject]
    private void Construct(WriteInFile writeInFile)
    {
        _writeInFile = writeInFile;
    }

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
        SceneManager.LoadScene(_writeInFile.ReadLevelFormXml());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
