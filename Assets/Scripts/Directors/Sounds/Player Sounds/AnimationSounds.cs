using UnityEngine;
using Random = System.Random;

namespace Directors
{
    public class AnimationSounds : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField, Range(0,1)] private float levelStartVolume;
        [SerializeField, Range(0,1)] private float winGameVolume;
        [SerializeField, Range(0,1)] private float deathVolume;
    
        [Header("Sounds"), Space(10)] 
        [SerializeField] private AudioClip levelStartSound;
        [SerializeField] private AudioClip winGameSound;
        [SerializeField] private AudioClip[] deathSound;

        [Header("Reference to Animation Events"), Space(10)] 
        [SerializeField] private AnimationsEvents animationEvents;

        private void Start()
        {
            animationEvents.OnLevelStartEvents += PlayLevelStartSound;
            animationEvents.OnWinGameEvents += PlayWinGameSound;
            animationEvents.OnDeathStartEvents += PlayDeathSound;
        }

        private void OnDestroy()
        {
            animationEvents.OnLevelStartEvents -= PlayLevelStartSound;
            animationEvents.OnWinGameEvents -= PlayWinGameSound;
            animationEvents.OnDeathStartEvents -= PlayDeathSound;
        }

        private void PlayLevelStartSound()
        {
            PlayAudioClipWithVolume(levelStartSound, levelStartVolume);
        }

        private void PlayWinGameSound()
        {
            PlayAudioClipWithVolume(winGameSound,winGameVolume);
        }

        private void PlayDeathSound()
        {
            var random = new Random();
            var randomSound = random.Next(0, deathSound.Length);
            
            PlayAudioClipWithVolume(deathSound[randomSound], deathVolume);
        }

        private void PlayAudioClipWithVolume(AudioClip clip, float volume)
        {
            audioSource.PlayOneShot(clip,volume);
        }
    }
}