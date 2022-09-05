using Interfaces;
using UnityEngine;
using Zenject;

namespace Directors
{
    public class DoorSoundsPlayer : MonoBehaviour
    {
        [Header("Sounds references")]
        [SerializeField] private AudioClip _openSound;
        [SerializeField] private AudioClip _closeSound;
        
        private DoorSounds _doorSounds;

        [Inject]
        private void Construct(ICanPlayAudio audioPlayer)
        {
            var door = GetComponent<Door>();
            _doorSounds = new DoorSounds(door, audioPlayer,_openSound, _closeSound);
        }
        
        private void OnDestroy()
        {
            _doorSounds.LastBreath();
        }
    }
}