using Directors;
using Zenject;

public class SceneChangerInstaller : MonoInstaller
{
        public override void InstallBindings()
        {
                var sceneChanger = new SceneChanger();
                Container.Bind<SceneChanger>().FromInstance(sceneChanger).AsSingle().NonLazy();
        }
}