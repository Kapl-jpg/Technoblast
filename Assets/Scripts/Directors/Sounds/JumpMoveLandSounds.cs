using System;
using UnityEngine;
using Zenject;

public class JumpMoveLandSounds : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0,1)] private float _moveVolume;
    [SerializeField, Range(0,1)] private float _jumpVolume;
    [SerializeField, Range(0,1)] private float _landVolume;
    
    [Header("Sounds"), Space(10)] 
    [SerializeField] private AudioClip _moveSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _landSound;

    private InputHandler _playerInputs;
    
    [Inject]
    private void Construct(InputHandler inputs)
    {
        _playerInputs = inputs;
        _playerInputs.OnLandedEvent += PlayLandSound;
    }

    private void OnDestroy()
    {
        _playerInputs.OnLandedEvent -= PlayLandSound;
    }

    private void Update()
    {
        PlaySoundOnMoves();
    }

    private void PlaySoundOnMoves()
    {
        if(_playerInputs.Jump && _playerInputs.IsGrounded)
            _audioSource.PlayOneShot(_jumpSound, _jumpVolume);
    }

    private void PlayLandSound()
    {
        _audioSource.PlayOneShot(_landSound, _landVolume);
    }
    
    public void PlayMoveSound()
    {
        _audioSource.PlayOneShot(_moveSound, _moveVolume);
    }
}
