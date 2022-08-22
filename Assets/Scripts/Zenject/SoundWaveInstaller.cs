using UnityEngine;
using Zenject;

public class SoundWaveInstaller : MonoInstaller
{
    [SerializeField] private SoundWave characterSoundWave;
    
    public override void InstallBindings()
    {
        Container.Bind<SoundWave>().FromInstance(characterSoundWave).AsSingle().NonLazy();
    }
}