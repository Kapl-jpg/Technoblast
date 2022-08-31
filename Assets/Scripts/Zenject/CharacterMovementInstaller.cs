using UnityEngine;
using Zenject;

public class CharacterMovementInstaller : MonoInstaller
{
    [SerializeField] private CharacterMovement characterMovement;
    public override void InstallBindings()
    {
        Container.Bind<CharacterMovement>().FromInstance(characterMovement).AsSingle().NonLazy();
        Container.Bind<InputHandler>().FromInstance(characterMovement.gameObject.GetComponent<InputHandler>())
            .AsSingle().NonLazy();
        Container.Bind<ICanDie>().FromInstance(characterMovement.gameObject.GetComponent<ICanDie>()).AsSingle().NonLazy();
    }
}