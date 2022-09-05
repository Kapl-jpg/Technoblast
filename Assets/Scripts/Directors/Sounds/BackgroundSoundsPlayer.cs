using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsContainer _soundsContainer;
        
        private AudioSource _audioSource;

        private void Start()
        {
            DontDestroyOnLoad(this);
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