using Directors;
using Interfaces;
using UnityEngine;
using Zenject;

public class BackgroundMusicSwithcer : MonoBehaviour
{
    private ILevelEnd _levelEnd;
    
    [Inject]
    private void Contstruct(ILevelEnd levelEnd)
    {
        _levelEnd = levelEnd;
        _levelEnd.OnLevelEndEvent += SwitchToNextSoundTheme;
    }

    private void OnDestroy()
    {
        _levelEnd.OnLevelEndEvent -= SwitchToNextSoundTheme;
    }

    private void SwitchToNextSoundTheme()
    {
        BackgroundSoundsPlayer.Instance.PlayNextSoundTheme(); 
    }
}
