using UnityEngine;

namespace Zenject
{
    public class ICanDieInstaller : MonoInstaller
    {
        [SerializeField] private MainCharacter _mainCharacter;
        
        public override void InstallBindings()
        {
            Container.Bind<ICanDie>().FromInstance(_mainCharacter.gameObject.GetComponent<ICanDie>()).AsSingle().NonLazy();
        }
    }
}