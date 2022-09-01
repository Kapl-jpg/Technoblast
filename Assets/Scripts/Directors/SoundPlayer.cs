using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SoundWave _playerSoundWave;
    [SerializeField] private AudioSource _audioSource;
    
    [Header("Miss Audio Clip"), Space(10)]
    [SerializeField] private AudioClip _onMissHitAudio;

    private void Start()
    {
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
        if (_audioSource.clip == audioClip)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.PlayOneShot(audioClip);
            _audioSource.clip = audioClip;
        }
    }
}
