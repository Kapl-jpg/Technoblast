using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsContainer _soundsContainer;

        private AudioSource _audioSource;

        private  static BackgroundSoundsPlayer _instance;

        private void Start()
        {
            Config();
        }

        private void Config()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
                StartPlayingSoundTheme();
            }
            else
            {
                Destroy(gameObject);
            }
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