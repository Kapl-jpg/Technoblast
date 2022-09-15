using System.Collections.Generic;
using Directors;
using Interfaces;
using UnityEngine;

public class SoundPlayer : MonoBehaviour, ICanPlayAudio
{
    [Header("References")]
    [SerializeField] private AudioSource _audioSource;
    
    [Header("SoundWave references"), Space(10)]
    [SerializeField] private SoundWave _playerSoundWave;
    [SerializeField] private AudioClip _onMissHitAudio;
    
    
    [Header("Inventory references"), Space(10)]
    [SerializeField] private InventoryComponent _playerInventory;
    [SerializeField, Range(0, 1)] private float _inventorySoundVolume;
    [SerializeField] private AudioClip _onSprayCanGetAudio;
    
    [Header("Trick references"), Space(10)]
    [SerializeField] private TrickMove _playerTrickMove;
    [SerializeField, Range(0, 1)] private float _trickSoundVolume;
    [SerializeField] private SoundsContainer _trickAudios;

    private List<ILastBreath> _unfollowScriptsList = new List<ILastBreath>();

    public AudioClip CurrentClip
    {
        get
        {
            return _audioSource.clip;
        }

        set
        {
            if (value != _audioSource.clip)
                _audioSource.clip = value;
        }
    }

    private void Start()
    {
        InitSoundWaveSounds();
        InitGraffitiSounds();
        InitTrickSounds();
    }

    private void OnDestroy()
    {
        LastBreath();
    }

    private void LastBreath()
    {
        foreach (var item in _unfollowScriptsList)
        {
            item.LastBreath();
        }
    }

    private void InitSoundWaveSounds()
    {
        var waveSounds = new SoundWaveSounds(_playerSoundWave, this, _onMissHitAudio);
        
        AddToFollowScriptsList(waveSounds);  
    }
    
    private void InitGraffitiSounds()
    {
        var inventorySounds = new InventorySounds(_playerInventory, this, _onSprayCanGetAudio, _inventorySoundVolume);
        
        AddToFollowScriptsList(inventorySounds);  
    }
    
    private void InitTrickSounds()
    {
        var trickSounds = new TrickMoveSounds(_playerTrickMove, this, _trickAudios, _trickSoundVolume);
        
        AddToFollowScriptsList(trickSounds);  
    }

    private void AddToFollowScriptsList(ILastBreath lastBreath)
    {
        _unfollowScriptsList.Add(lastBreath);
    }
    
    public void PlayOneShot(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }

    public void PlayOneShot(AudioClip audio, float volume)
    {
        _audioSource.PlayOneShot(audio,volume);
    }

    public void Play(AudioClip audio)
    {
        _audioSource.clip = audio;
        _audioSource.Play();
    }
}
