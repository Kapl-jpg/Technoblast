using Interfaces;
using UnityEngine;

namespace Directors
{
    public class TrickMoveSounds : ILastBreath
    {
        private TrickMove _trickMove;
        private AudioSource _audioSource;
        private SoundsContainer _sounds;
        
        public TrickMoveSounds(TrickMove trickMove, AudioSource audioSource, SoundsContainer sounds)
        {
            _trickMove = trickMove;
            _audioSource = audioSource;
            _sounds = sounds;

            _trickMove.OnTrickPressedEvent += PlayRandomAudioClip;
        }
        
        public void LastBreath()
        {
            _trickMove.OnTrickPressedEvent -= PlayRandomAudioClip;
        }

        private void PlayRandomAudioClip()
        {
            if (_sounds.IsAvailableClips())
            {
               var audio = _sounds.GetRandomAudioClip();
               _audioSource.PlayOneShot(audio);
            }
        }
    }
}