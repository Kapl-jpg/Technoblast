using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

namespace Directors
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [Inject]
        private void Construct(ICanDie player)
        {
            player.OnDeathEvent += RestartLevel;
        }

        private void RestartLevel()
        {
            var sceneLoader = new SceneLoader();
            sceneLoader.RestartCurrentScene();
        }
    }
}