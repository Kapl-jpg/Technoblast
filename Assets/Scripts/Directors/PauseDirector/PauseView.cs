using UnityEngine;
using Zenject;

public class PauseView : MonoBehaviour
{
    private InputHandler _inputHandler;

    [Inject]
    private void Construct(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
}