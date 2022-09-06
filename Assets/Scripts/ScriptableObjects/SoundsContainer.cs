using System;
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