using UnityEngine;
using Zenject;

namespace Directors.PauseDirector
{
    public class PauseView : MonoBehaviour
    {
        private PauseDirector _pauseDirector;
        private InputHandler _inputHandler;

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

        public void SwitchState()
        {
            _pauseDirector.ChangePauseState();
        }
    }
}