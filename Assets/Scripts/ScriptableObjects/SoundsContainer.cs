using ModestTree;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundsContainer", menuName = "ScriptableObjects/SoundsContainer", order = 2)]
public class SoundsContainer : ScriptableObject
{
    [SerializeField] private AudioClip[] _audioClips;

    public AudioClip[] AudioClips => _audioClips;

    public bool IsAvailableClips()
    {
        return AudioClips.Length > 0;
    }

    public AudioClip GetFirstAvailableAudioClip()
    {
        if (IsAvailableClips())
            return _audioClips[0];
        
        return null;
    }
    
    public AudioClip GetNextAvailableAudioClip(AudioClip currentAudioClip)
    {
        var clipsContainsAudio = AudioClips.IndexOf(currentAudioClip) > -1;
        
        if(clipsContainsAudio)
        {
            var indexOfCurrentAudio = AudioClips.IndexOf(currentAudioClip);
            if (indexOfCurrentAudio < AudioClips.Length)
                return AudioClips[indexOfCurrentAudio + 1];
        }

        return null;
    }
    
    public AudioClip GetRandomAudioClip()
    {
        if (IsAvailableClips())
        {
            var random = new System.Random();
            var availableAudioClips = _audioClips.Length;
            return _audioClips[random.Next(0, availableAudioClips)];
        }

        return null;
    }
}