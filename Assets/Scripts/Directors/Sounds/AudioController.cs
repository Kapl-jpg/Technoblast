using System.Collections.Generic;
using ScriptableObjects.Sounds_SO;
using UnityEngine;

namespace Directors
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private Profiles _profiles;
        [SerializeField] private List<MusicSlider> _volumeSlider = new List<MusicSlider>();
        public Profiles Profile
        {
            get => _profiles;
        }

        private void Awake()
        {
            if(_profiles !=null)
                _profiles.SetProfile(_profiles);
        }

        private void Start()
        {
            if(Settings.Profile && Settings.Profile.AudioMixer != null)
                Settings.Profile.GetAudioLevels();
        }

        public void ApplyChanges()
        {
            if(Settings.Profile && Settings.Profile.AudioMixer != null)
                Settings.Profile.SaveAudioLevels();
        }

        public void CancelChanges()
        {
            if(Settings.Profile && Settings.Profile.AudioMixer != null)
                Settings.Profile.GetAudioLevels();
            
            for (int i = 0; i < _volumeSlider.Count; i++)
            {
                _volumeSlider[i].ResetSliderValue();
            }
        }
    }
}