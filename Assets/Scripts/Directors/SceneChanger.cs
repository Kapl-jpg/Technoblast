using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;
using Zenject;

public class SceneChanger : MonoBehaviour
{
    private DataFile _dataFile;
    [SerializeField] private int[] excludeIndexScene;
    public int IndexNextScene { get; set; }

    [Inject]
    private void Construct(DataFile writeInFile)
    {
        _dataFile = writeInFile;
    }

    private void Start()
    {
        SaveLevelNumber();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame(int cutsceneNumber)
    {
        if (_dataFile.ReadCutscene() == 0)
            SceneManager.LoadScene(cutsceneNumber);
        else
            LoadNextScene();
    }

    public void LoadSceneAnimation()
    {
        SceneManager.LoadScene(IndexNextScene);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneIndexNumber(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void SaveLevelNumber()
    {
        if (excludeIndexScene.Any(index => SceneManager.GetActiveScene().buildIndex == index))
            return;

        _dataFile.WriteLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(_dataFile.ReadLevel());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
