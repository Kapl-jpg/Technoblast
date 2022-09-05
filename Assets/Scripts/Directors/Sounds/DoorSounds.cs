using Interfaces;
using UnityEngine;

namespace Directors
{
    public class DoorSounds: ILastBreath
    {
        private Door _door;
        private ICanPlayAudio _audioPlayer;
        private AudioClip _openDoorSound;
        private AudioClip _closeDoorSound;
        
        public DoorSounds(Door door, ICanPlayAudio audioPlayer, AudioClip openDoorSound, AudioClip closeDoorSound)
        {
            _door = door;
            _audioPlayer = audioPlayer;
            _openDoorSound = openDoorSound;
            _closeDoorSound = closeDoorSound;

            _door.OnDoorOpenEvent += PlayOpenDoorSound;
            _door.OnDoorCloseEvent += PlayCloseDoorSound;
        }

        public void LastBreath()
        {
            _door.OnDoorOpenEvent -= PlayOpenDoorSound;
            _door.OnDoorCloseEvent -= PlayCloseDoorSound;
        }

        private void PlayOpenDoorSound()
        {
            _audioPlayer.PlayOneShot(_openDoorSound);
        }

        private void PlayCloseDoorSound()
        {
            _audioPlayer.PlayOneShot(_closeDoorSound);
        }
    }
}