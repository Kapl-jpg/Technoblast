using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : SingleInstanceObject
    {
        [SerializeField] private SoundsContainer _soundsContainer;

        private AudioSource _audioSource;

        protected override void Init()
        {
            StartPlayingSoundTheme();
        }

        private void StartPlayingSoundTheme()
        {
            _audioSource = GetComponent<AudioSource>();
            
            if (_soundsContainer.IsAvailableClips())
            {
                _audioSource.clip = _soundsContainer.GetFirstAvailableAudioClip();
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }
    }
}