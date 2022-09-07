using Directors.PauseDirector;
using Interfaces;
using UnityEngine;

namespace Zenject
{
    public class PauseDirectorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var pauseDirector = new PauseDirector();
            Container.Bind<IPauseDirector>().FromInstance(pauseDirector).AsSingle().NonLazy();
            Container.Bind<PauseDirector>().FromInstance(pauseDirector).AsSingle().NonLazy();
        }
    }
}