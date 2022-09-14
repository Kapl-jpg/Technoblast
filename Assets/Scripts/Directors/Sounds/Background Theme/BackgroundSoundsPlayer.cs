using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsContainer _soundsContainer;
        
        public static BackgroundSoundsPlayer Instance => _instance;
        private static BackgroundSoundsPlayer _instance;

        public AudioClip CurrentAudioClip => _audioSource.clip;
        
        private AudioSource _audioSource;

        private void Awake()
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
                PlayFirstSoundTheme();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void PlayFirstSoundTheme()
        {
            if (_soundsContainer.IsAvailableClips())
            {
                var firstSoundTheme = _soundsContainer.GetFirstAvailableAudioClip();
                StartPlayingSoundTheme(firstSoundTheme);
            }
        }

        private void StartPlayingSoundTheme(AudioClip soundTheme)
        {
            _audioSource.clip = soundTheme;
            _audioSource.loop = true;
            _audioSource.Play();
        }
        
        public bool PlayNextSoundTheme()
        {
            var nextSoundTheme = _soundsContainer.GetNextAvailableAudioClip(_audioSource.clip);
            var soundThemeExist = nextSoundTheme != null;
            
            if (soundThemeExist)
            {
                StartPlayingSoundTheme(nextSoundTheme);
            }

            return soundThemeExist;
        }
        
        public void PlaySoundTheme(AudioClip soundTheme)
        {
            StartPlayingSoundTheme(soundTheme);
        }
    }
}