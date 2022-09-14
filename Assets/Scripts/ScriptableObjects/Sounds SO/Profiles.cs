using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Audio;

namespace ScriptableObjects.Sounds_SO
{
    [CreateAssetMenu(fileName = "Profile", menuName = "ScriptableObjects/CreateProfile", order = 4)]
    public class Profiles : ScriptableObject
    {
        [SerializeField] private bool _saveInPlayerPrefs = true;
        [SerializeField] private string _prefPrefix = "Settings_";
        [SerializeField] private AudioMixer _audioMixer;
        public AudioMixer AudioMixer => _audioMixer;
        [SerializeField] private Volume[] _volumeControl;

        public void SetProfile(Profiles profile)
        {
            Settings.Profile = profile;
        }

        public float GetAudioLevels(string name)
        {
            var volume = 1f;

            if (!_audioMixer)
            {
                Debug.LogError("There is no AudioMixer defined in the profiles file");
                return volume;
            }

            for (int i = 0; i < _volumeControl.Length; i++)
            {
                if(_volumeControl[i].Name == name)
                {
                    if (_saveInPlayerPrefs)
                    {
                        if (PlayerPrefs.HasKey(_prefPrefix + _volumeControl[i].Name))
                        {
                            _volumeControl[i].CurrentVolume =
                                PlayerPrefs.GetFloat(_prefPrefix + _volumeControl[i].Name);
                        }
                    }

                    _volumeControl[i].TempVolume = _volumeControl[i].CurrentVolume;
                    
                    if (AudioMixer)
                    {
                        var soundVolume = Mathf.Log(_volumeControl[i].CurrentVolume) * 20f;
                        AudioMixer.SetFloat(_volumeControl[i].Name, soundVolume);
                    }

                    volume = _volumeControl[i].CurrentVolume;
                    break;
                }
            }

            return volume;
        }

        public void GetAudioLevels()
        {
            if (!_audioMixer)
            {
                Debug.LogError("There is no AudioMixer defined in the profiles file");
                return;
            }

            for (int i = 0; i < _volumeControl.Length; i++)
            {
                if (_saveInPlayerPrefs)
                {
                    if (PlayerPrefs.HasKey(_prefPrefix + _volumeControl[i].Name))
                    {
                        _volumeControl[i].CurrentVolume = PlayerPrefs.GetFloat(_prefPrefix + _volumeControl[i].Name);
                    }
                }

                _volumeControl[i].TempVolume = _volumeControl[i].CurrentVolume;

                _audioMixer.SetFloat(_volumeControl[i].Name, Mathf.Log(_volumeControl[i].CurrentVolume) * 20f);
            }
        }

        public void SetAudioLevels(string name, float volume)
        {
            if (!_audioMixer)
            {
                Debug.LogError("There is no AudioMixer defined in the profiles file");
                return;
            }

            for (int i = 0; i < _volumeControl.Length; i++)
            {
                if (_volumeControl[i].Name == name)
                {
                    _audioMixer.SetFloat(_volumeControl[i].Name, Mathf.Log(volume) * 20f);
                    _volumeControl[i].TempVolume = volume;
                    break;
                }
            }
        }

        public void SaveAudioLevels()
        {
            if (!_audioMixer)
            {
                Debug.LogError("There is no AudioMixer defined in the profiles file");
                return;
            }

            var volume = 0f;
            for (int i = 0; i < _volumeControl.Length; i++)
            {
                volume = _volumeControl[i].TempVolume;
                if (_saveInPlayerPrefs)
                {
                    PlayerPrefs.SetFloat(_prefPrefix+_volumeControl[i].Name, volume);
                }

                _audioMixer.SetFloat(_volumeControl[i].Name, Mathf.Log(volume) * 20f);
                _volumeControl[i].CurrentVolume = volume;
            }
        }
    }
    
    [Serializable]
    public class Volume
    {
        public string Name;
        public float CurrentVolume =1f;
        public float TempVolume =1f;
    }

    public class Settings
    {
        public static Profiles Profile;
    }
}