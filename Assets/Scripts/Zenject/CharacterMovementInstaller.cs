using UnityEngine;
using Zenject;

public class CharacterMovementInstaller : MonoInstaller
{
    [SerializeField] private CharacterMovement characterMovement;
    public override void InstallBindings()
    {
        Container.Bind<CharacterMovement>().FromInstance(characterMovement).AsSingle().NonLazy();
    }
}