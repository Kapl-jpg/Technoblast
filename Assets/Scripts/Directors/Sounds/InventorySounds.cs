using Interfaces;
using UnityEngine;

namespace Directors
{
    public class InventorySounds : ILastBreath
    {
        private InventoryComponent _inventory;
        private ICanPlayAudio _audioPlayer;
        private AudioClip _audioClip;

        public InventorySounds(InventoryComponent inventory, ICanPlayAudio audioPlayer, AudioClip audioClip)
        {
            _inventory = inventory;
            _audioPlayer = audioPlayer;
            _audioClip = audioClip;
            
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
            _audioPlayer.PlayOneShot(_audioClip);
        }
    }
}