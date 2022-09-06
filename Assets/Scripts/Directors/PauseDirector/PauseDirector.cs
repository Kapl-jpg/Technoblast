using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Directors.PauseDirector
{
    public class PauseDirector: IPauseDirector
    {
        public bool PauseState => _pauseState;
        private bool _pauseState;
        
        private List<ICanBePaused> _pausables = new List<ICanBePaused>();

        public void RegisterICanBePausedActor(ICanBePaused actor)
        {
            if (!_pausables.Contains(actor))
            {
                _pausables.Add(actor);
            }
            else
            {
                Debug.LogError($"Actor {actor} added twice");
            }
        }

        public void ChangePauseState()
        {
            _pauseState = !_pauseState;
            
            if (_pauseState)
            {
                foreach (var actor in _pausables)
                {
                    actor.Pause();
                }
            }
            else
            {
                foreach (var actor in _pausables)
                {
                    actor.Unpause();
                }
            }
        }
    }
}