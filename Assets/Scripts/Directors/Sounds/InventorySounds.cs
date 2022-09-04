using Interfaces;
using UnityEngine;

namespace Directors
{
    public class InventorySounds : ILastBreath
    {
        private InventoryComponent _inventory;
        private AudioSource _audioSource;
        private AudioClip _audioClip;

        public InventorySounds(InventoryComponent inventory, AudioSource audioSource, AudioClip audioClip)
        {
            _inventory = inventory;
            _audioSource = audioSource;
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
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}