using Interfaces;

namespace Zenject
{
    public class ILevelEndInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var levelEnd = FindObjectOfType<LevelEndPortal>();
            
            Container.Bind<ILevelEnd>().FromInstance(levelEnd.GetComponent<ILevelEnd>()).AsSingle().NonLazy();
        }
    }
}