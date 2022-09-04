using Interfaces;
using UnityEngine;

namespace Directors
{
    public class SoundWaveSounds: ILastBreath
    {
        private SoundWave _playerSoundWave;
        private AudioSource _audioSource;
        private AudioClip _onMissHitAudio;

        public SoundWaveSounds(SoundWave playerSoundWave, AudioSource audioSource, AudioClip onMissHitAudio)
        {
            _playerSoundWave = playerSoundWave;
            _audioSource = audioSource;
            _onMissHitAudio = onMissHitAudio;
            
            _playerSoundWave.JumpableObjectHitEvent += PlayJumpableObjectSound;
            _playerSoundWave.JumpableObjectMissEvent += PlayMissHitSound;
        }
        
        
        public void LastBreath()
        {
            _playerSoundWave.JumpableObjectHitEvent -= PlayJumpableObjectSound;
            _playerSoundWave.JumpableObjectMissEvent -= PlayMissHitSound;
        }

        private void PlayJumpableObjectSound(JumpableObjectData jumpableObjectData)
        {
            SetAudioAndPlay(jumpableObjectData.ObjectHitAudio);
        }

        private void PlayMissHitSound()
        {
            SetAudioAndPlay(_onMissHitAudio);
        }

        private void SetAudioAndPlay(AudioClip audioClip)
        {
            if (_audioSource.clip == audioClip)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.PlayOneShot(audioClip);
                _audioSource.clip = audioClip;
            }
        }
    }
}