using UnityEngine;
using Zenject;

namespace Directors.PauseDirector
{
    public class PauseView : MonoBehaviour
    {
        private PauseDirector _pauseDirector;
        private InputHandler _inputHandler;

        private bool _pauseState;
        
        [Inject]
        private void Construct(PauseDirector pauseDirector, InputHandler inputHandler)
        {
            _pauseDirector = pauseDirector;
            _inputHandler = inputHandler;
        }

        private void Update()
        {
            if (_inputHandler.Pause)
            {
                SwitchState();
            }
        }

        private void SwitchState()
        {
            if (!_pauseState)
            {
                _pauseState = true;
            }
            else
            {
                _pauseState = false;
            }
            
            _pauseDirector.ChangePauseState();
        }
    }
}