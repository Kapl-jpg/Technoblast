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
}