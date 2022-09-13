using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Directors
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        private ICanDie _player;
        private SceneChanger _sceneChanger;
        private List<Action> _playerDeathFollowers = new List<Action>();
        
        [Inject]
        private void Construct(ICanDie player, SceneChanger sceneChanger)
        {
            _player = player;

            _sceneChanger = sceneChanger;
        }
        
        private void Start()
        {
            FollowPlayerDeath(_sceneChanger.RestartCurrentScene);
        }
        
        public void FollowPlayerDeath(Action methodToFollow)
        {
            if (!_playerDeathFollowers.Contains(methodToFollow))
            {
                _player.OnDeathEvent += methodToFollow;
                _playerDeathFollowers.Add(methodToFollow);   
            }
        }
        
        public bool UnFollowPlayerDeath(Action methodToUnfollow)
        {
            if (_playerDeathFollowers.Contains(methodToUnfollow))
            {
                _player.OnDeathEvent -= methodToUnfollow;
                _playerDeathFollowers.Remove(methodToUnfollow);
                return true;
            }

            return false;
        }
        
        private void OnDestroy()
        {
            UnFollowEvents();
        }
        
        private void UnFollowEvents()
        {
            UnFollowPlayerDeath(_sceneChanger.RestartCurrentScene);
            
            foreach (var method in _playerDeathFollowers)
            {
                _player.OnDeathEvent -= method;
            }
        }
    }
}