using UnityEngine;
using System.IO;
using Application = UnityEngine.Application;
using UnityEngine.SceneManagement;
using Zenject;

public class WriteInFile : MonoBehaviour
{
    private string _dataFolderName = "SaveData";
    private string _levelFileName = "LevelNumber";

    private SceneChanger _changer;

    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _changer = sceneChanger;
    }

    public int ReadLevelNumber()
    {
        if (File.Exists(Path()))
        {
            var text = File.ReadAllText(Path());
            if (text != "")
            {
                return int.Parse(text);
            }
        }
        return 0;
    }

    private void Start()
    {
        InitialFile(Application.persistentDataPath + "/" + _dataFolderName);
        WriteLevelNumber();
        
    }
    private string Path()
    {
        return (Application.persistentDataPath + "/" + "SaveData" + "/" + "LevelNumber" + ".txt");
    }

    private void WriteLevelNumber()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
            return;

        File.WriteAllText(Path(), SceneManager.GetActiveScene().buildIndex.ToString());
    }

    private void InitialFile(string path)
    {
        var filePath = path + "/" + _levelFileName + ".txt";

        if (!Directory.Exists(path) || !File.Exists(filePath))
        {
            CreateDirectory(path);
            CreateFile(filePath);
        }
    }

    private void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private void CreateFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
    }
}
