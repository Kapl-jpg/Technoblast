using System.Collections.Generic;
using Directors;
using Interfaces;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource _audioSource;
    
    [Header("SoundWave references"), Space(10)]
    [SerializeField] private SoundWave _playerSoundWave;
    [SerializeField] private AudioClip _onMissHitAudio;

    [Header("Inventory references"), Space(10)]
    [SerializeField] private InventoryComponent _playerInventory;
    [SerializeField] private AudioClip _onSprayCanGetAudio;
    
    private List<ILastBreath> _unfollowScriptsList = new List<ILastBreath>();

    private void Start()
    {
        InitSoundWaveSounds();
        InitGraffitiSounds();
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
        var waveSounds = new SoundWaveSounds(_playerSoundWave, _audioSource, _onMissHitAudio);
        
        if (waveSounds is ILastBreath)
        {
            _unfollowScriptsList.Add(waveSounds);
        }
    }

    private void InitGraffitiSounds()
    {
        var inventorySounds = new InventorySounds(_playerInventory, _audioSource, _onSprayCanGetAudio);
        
        if (inventorySounds is ILastBreath)
        {
            _unfollowScriptsList.Add(inventorySounds);
        }
    }
}
