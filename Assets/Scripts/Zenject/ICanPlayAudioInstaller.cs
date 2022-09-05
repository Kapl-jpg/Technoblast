using Interfaces;
using UnityEngine;
using Zenject;

public class ICanPlayAudioInstaller : MonoInstaller
{
    [SerializeField] private SoundPlayer ICanPlayAudioObject;
    
    public override void InstallBindings()
    {
        if(ICanPlayAudioObject is ICanPlayAudio)
            Container.Bind<ICanPlayAudio>().FromInstance(ICanPlayAudioObject).AsSingle().NonLazy();
    }
}