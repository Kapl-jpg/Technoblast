using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsContainer _soundsContainer;

        private static BackgroundSoundsPlayer _instance;

        private AudioSource _audioSource;

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
                _audioSource = GetComponent<AudioSource>();
                StartPlayingSoundTheme();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void StartPlayingSoundTheme()
        {
            if (_soundsContainer.IsAvailableClips())
            {
                _audioSource.clip = _soundsContainer.GetFirstAvailableAudioClip();
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }
    }
}