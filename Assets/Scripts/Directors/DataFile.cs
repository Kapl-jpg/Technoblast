using UnityEngine;
using System.IO;
using Application = UnityEngine.Application;

public class DataFile : MonoBehaviour
{
    private readonly string _dataFolderName = "SaveData";
    [SerializeField] private string settingsFileName = "SettingsData";
    private SettingsData _settingsData;
    private string _filePath;

    private void Start()
    {
        GetData();
        
        var folderPath = Application.persistentDataPath + "/" + _dataFolderName;
        InitialFile(folderPath, $"{settingsFileName}.json");
    }

    private void GetData()
    {
        _filePath =$"{Application.persistentDataPath}/{_dataFolderName}/{settingsFileName}.json";
        _settingsData = new SettingsData();
    }

    private void InitialFile(string path,string fileName)
    {
        var filePath = path + "/" + fileName;

        if (!Directory.Exists(path))
            CreateDirectory(path);

        if (!File.Exists(filePath))
            CreateFile(filePath);
    }

    private static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private static void CreateFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
    }

    private bool FileIsEmpty(string path)
    {
        if(File.Exists(path))
            return File.ReadAllText(path) == string.Empty;
        return true;
    }
    
    #region LevelSetting

    public void WriteLevel(int levelNumber)
    {
        GetData();
        
        if (!FileIsEmpty(_filePath))
            _settingsData = ReadSettingsData(_filePath);

        _settingsData.levelNumber = levelNumber;
        
        var json = JsonUtility.ToJson(_settingsData);
        File.WriteAllText(_filePath,json);
    }

    public int ReadLevel()
    {
        GetData();
        
        if (FileIsEmpty(_filePath)) return 0;
        _settingsData = ReadSettingsData(_filePath);
        return _settingsData.levelNumber;
    }
    
    #endregion

    #region SoundsSetting

    public void WriteSoundsVolume(int soundVolume)
    {
        if (!FileIsEmpty(_filePath))
            _settingsData = ReadSettingsData(_filePath);

        _settingsData.soundVolume = soundVolume;
        
        var json = JsonUtility.ToJson(_settingsData);
        File.WriteAllText(_filePath,json);
    }
    
    public int ReadSoundsVolume()
    {
        GetData();

        if (FileIsEmpty(_filePath)) return 4;
        _settingsData = ReadSettingsData(_filePath);
        return _settingsData.soundVolume;

    }
    
    #endregion
    
    #region MusicSetting

    public void WriteMusicVolume(int musicVolume)
    {
        if (!FileIsEmpty(_filePath))
            _settingsData = ReadSettingsData(_filePath);

        _settingsData.musicVolume = musicVolume;
        
        var json = JsonUtility.ToJson(_settingsData);
        File.WriteAllText(_filePath,json);
    }

    public int ReadMusicVolume()
    {
        GetData();
        
        if (FileIsEmpty(_filePath)) return 4;
            _settingsData = ReadSettingsData(_filePath);
            return _settingsData.musicVolume;
    }

    #endregion

    #region Cutscene

    public void WriteCutscene()
    {
        GetData();
        
        if (!FileIsEmpty(_filePath))
            _settingsData = ReadSettingsData(_filePath);

        _settingsData.cutscene = 1;
        
        var json = JsonUtility.ToJson(_settingsData);
        File.WriteAllText(_filePath,json);
    }

    public int ReadCutscene()
    {
        GetData();
        
        if (FileIsEmpty(_filePath)) return 0;
        _settingsData = ReadSettingsData(_filePath);
        return _settingsData.cutscene;
    }

    #endregion

    #region Spray count

    public void WriteSprayCount(int sprayCount)
    {
        GetData();
        
        if (!FileIsEmpty(_filePath))
            _settingsData = ReadSettingsData(_filePath);

        _settingsData.sprayCount = sprayCount;

        var json = JsonUtility.ToJson(_settingsData);
        File.WriteAllText(_filePath, json);
    }

    public int ReadSprayCount()
    {
        GetData();

        if (!FileIsEmpty(_filePath))
        {
            _settingsData = ReadSettingsData(_filePath);
            return _settingsData.sprayCount;
        }

        return 0;
    }

    #endregion
    
    private static SettingsData ReadSettingsData(string path)
    {
        var jsonString = File.ReadAllText(path);
        return JsonUtility.FromJson<SettingsData>(jsonString);
    }
}

[System.Serializable]
public class SettingsData
{
    public int levelNumber;
    public int musicVolume;
    public int soundVolume;
    public int cutscene;
    public int sprayCount;
}