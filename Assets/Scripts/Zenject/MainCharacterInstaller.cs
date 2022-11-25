using UnityEngine;
using Zenject;

public class MainCharacterInstaller : MonoInstaller
{
    [SerializeField] private MainCharacter mainCharacter;
    public override void InstallBindings()
    {
        Container.Bind<MainCharacter>().FromInstance(mainCharacter).AsSingle().NonLazy();        
    }
}
