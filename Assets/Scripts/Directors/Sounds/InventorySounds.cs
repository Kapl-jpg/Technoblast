using Interfaces;
using UnityEngine;

namespace Directors
{
    public class InventorySounds : ILastBreath
    {
        private InventoryComponent _inventory;
        private ICanPlayAudio _audioPlayer;
        private AudioClip _audioClip;
        private float _volume;
        public InventorySounds(InventoryComponent inventory, ICanPlayAudio audioPlayer, AudioClip audioClip, float volume)
        {
            _inventory = inventory;
            _audioPlayer = audioPlayer;
            _audioClip = audioClip;
            _volume = volume;
            FollowInventoryEvents();
        }

        private void FollowInventoryEvents()
        {
            _inventory.OnItemAddedEvent += PlayItemTakeSound;
        }
        
        public void LastBreath()
        {
            _inventory.OnItemAddedEvent -= PlayItemTakeSound;
        }

        private void PlayItemTakeSound()
        {
            _audioPlayer.PlayOneShot(_audioClip, _volume);
        }
    }
}