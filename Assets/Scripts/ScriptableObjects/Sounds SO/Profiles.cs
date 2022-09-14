using System;
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
        
         
    }
    
    [Serializable]
    public class Volume
    {
        public string Name;
        public float CurrentVolume;
        public float TempVolume;
    }

    public class Settings
    {
        public static Profiles Profile;
    }
}