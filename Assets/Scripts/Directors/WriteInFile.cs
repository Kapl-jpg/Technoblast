using UnityEngine;
using System.IO;
using Application = UnityEngine.Application;
using UnityEngine.SceneManagement;
using System.Xml.Linq;

public class WriteInFile : MonoBehaviour
{
    private readonly string _dataFolderName = "SaveData";
    private readonly string _levelFileName = "Data";

    private readonly string _dataElement = "Data";
        private readonly string _levelElement = "Level";
        private readonly string _numberElement = "Number";


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
        WriteInXmlFile();
    }
    private string Path()
    {
        return (Application.persistentDataPath + "/" + _dataFolderName + "/" + _levelFileName + ".xml");
    }

    private void InitialFile(string path)
    {
        var filePath = path + "/" + _levelFileName + ".xml";

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
    #region Level

    private void WriteLevel(XElement xElement)
    {
        XElement level = new XElement(_levelElement);
        xElement.Add(level);

        XElement number = new XElement(_numberElement, CurrentLevelToString());
        level.Add(number);
    }

    public int ReadLevelFormXml()
    {
        XDocument doc = XDocument.Load(Path());
        XElement data = doc.Element(_dataElement);
        XElement level = data.Element(_levelElement);
        XElement number = level.Element(_numberElement);
        return int.Parse(number.Value);
    }

    #endregion

    private void WriteInXmlFile()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
            return;
        XDocument doc = new XDocument();
        XElement xElement = new XElement(_dataElement);

        WriteLevel(xElement);

        doc.Add(xElement);

        using StreamWriter sw = new StreamWriter(Path());
        string xDoc = doc.ToString();
        sw.WriteLine(xDoc);
    }    

    private string CurrentLevelToString()
    {
        return SceneManager.GetActiveScene().buildIndex.ToString();
    }    
}
