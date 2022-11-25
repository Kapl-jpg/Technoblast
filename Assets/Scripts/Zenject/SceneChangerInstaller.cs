using UnityEngine;
using Zenject;

public class SceneChangerInstaller : MonoInstaller
{
        [SerializeField] private SceneChanger sceneChanger;

        public override void InstallBindings()
        {
                Container.Bind<SceneChanger>().FromInstance(sceneChanger).AsSingle().NonLazy();
        }
}