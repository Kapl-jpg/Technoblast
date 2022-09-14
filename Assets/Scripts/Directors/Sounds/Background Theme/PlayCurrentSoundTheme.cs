using Directors;
using UnityEngine;

public class PlayCurrentSoundTheme : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClipToPlay;
    
    private AudioClip _cachedAudioCLip;
    
    void Start()
    {
        _cachedAudioCLip = BackgroundSoundsPlayer.Instance.CurrentAudioClip;
        
        BackgroundSoundsPlayer.Instance.PlaySoundTheme(_audioClipToPlay);       
    }

    private void OnDestroy()
    {
        BackgroundSoundsPlayer.Instance.PlaySoundTheme(_cachedAudioCLip);
    }
}
