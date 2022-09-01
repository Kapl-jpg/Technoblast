using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SoundWave _playerSoundWave;
    [SerializeField] private AudioSource _audioSource;
    
    [Header("Miss Audio Clip"), Space(10)]
    [SerializeField] private AudioClip _onMissHitAudio;

    [Header("Parallel Audio Clips Settings"), Space(10)]
    [SerializeField] private int _maxParallelClips;
    
    private List<AudioClip> _currentPlayingClips;

    private void Start()
    {
        _currentPlayingClips = new List<AudioClip>(_maxParallelClips);
        
        _playerSoundWave.JumpableObjectHitEvent += PlayJumpableObjectSound;
        _playerSoundWave.JumpableObjectMissEvent += PlayMissHitSound;
    }

    private void OnDestroy()
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
        if (!_currentPlayingClips.Contains(audioClip))
        {
            StartCoroutine(AudioClipCallback(audioClip));
            _audioSource.PlayOneShot(audioClip,0.5f);  
        }
    }

    private IEnumerator AudioClipCallback(AudioClip audioClip)
    {
        _currentPlayingClips.Add(audioClip);
        
        foreach (var clips in _currentPlayingClips)
        {
            Debug.Log(clips.name);
        }
        
        yield return new WaitForSeconds(audioClip.length);
        _currentPlayingClips.Remove(audioClip);
    }
}
