using UnityEngine;
using System.IO;
using Application = UnityEngine.Application;
using UnityEngine.SceneManagement;

public class WriteInFile : MonoBehaviour
{
    private string _dataFolderName = "SaveData";
    private string _levelFileName = "LevelNumber";

    //public int ReadLevelNumber()
    //{
    //    var path = Application.dataPath;
    //    var directory = Application.dataPath + "";
    //    var fileName = "LevelNumber.txt";
    //    var allPath = path + "/" + fileName;
    //    if (File.Exists(allPath))
    //    {
    //        StreamReader sr = new StreamReader(allPath);
    //        var text = File.ReadAllText(sr.ReadToEnd());
    //        return int.Parse(text);
    //    }
    //    return 0;
    //}

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
