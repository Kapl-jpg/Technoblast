using Interfaces;
using UnityEngine;
using Random = System.Random;

namespace Directors
{
    public class SoundWaveSounds: ILastBreath
    {
        private SoundWave _playerSoundWave;
        private ICanPlayAudio _audioPlayer;
        private AudioClip _onMissHitAudio;

        public SoundWaveSounds(SoundWave playerSoundWave, ICanPlayAudio audioPlayer, AudioClip onMissHitAudio)
        {
            _playerSoundWave = playerSoundWave;
            _audioPlayer = audioPlayer;
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
            var random = new Random();
            var randomSound = random.Next(0, jumpableObjectData.ObjectHitAudio.Length);
            SetAudioAndPlay(jumpableObjectData.ObjectHitAudio[randomSound]);
        }

        private void PlayMissHitSound()
        {
            SetAudioAndPlay(_onMissHitAudio);
        }

        private void SetAudioAndPlay(AudioClip audioClip)
        {
            if (_audioPlayer.CurrentClip == audioClip)
            {
                _audioPlayer.Play(audioClip);
            }
            else
            {
                _audioPlayer.PlayOneShot(audioClip);
                _audioPlayer.CurrentClip = audioClip;
            }
        }
    }
}