using UnityEngine;
using Random = System.Random;

namespace Directors
{
    public class AnimationSounds : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField, Range(0,1)] private float _levelStartVolume;
        [SerializeField, Range(0,1)] private float _winGameVolume;
        [SerializeField, Range(0,1)] private float _deathVolume;
    
        [Header("Sounds"), Space(10)] 
        [SerializeField] private AudioClip _levelStartSound;
        [SerializeField] private AudioClip _winGameSound;
        [SerializeField] private AudioClip[] _deathSound;

        [Header("Reference to Animation Events"), Space(10)] 
        [SerializeField] private AnimationsEvents _animationEvents;

        private void Start()
        {
            _animationEvents.OnWinGameEvents += PlayWinGameSound;
            _animationEvents.OnDeathStartEvents += PlayDeathSound;
        }

        private void OnDestroy()
        {
            _animationEvents.OnWinGameEvents -= PlayWinGameSound;
            _animationEvents.OnDeathStartEvents -= PlayDeathSound;
        }

        private void PlayLevelStartSound()
        {
            PlayAudioClipWithVolume(_levelStartSound, _levelStartVolume);
        }

        private void PlayWinGameSound()
        {
            PlayAudioClipWithVolume(_winGameSound,_winGameVolume);
        }

        private void PlayDeathSound()
        {
            var random = new Random();
            var randomSound = random.Next(0, _deathSound.Length);
            
            PlayAudioClipWithVolume(_deathSound[randomSound], _deathVolume);
        }

        private void PlayAudioClipWithVolume(AudioClip clip, float volume)
        {
            _audioSource.PlayOneShot(clip,volume);
        }
    }
}