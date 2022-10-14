using UnityEngine;
using Zenject;

public class PauseView : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private InputHandler _inputHandler;

    [Inject]
    private void Construct(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    private void Update()
    {
        TimeState();
    }

    private void TimeState()
    {
        if (_inputHandler.Pause)
        {
            if (Time.timeScale == 1)
            {
                PauseState();
            }
        }
    }

    private void PauseState()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseState()
    {
        Time.timeScale = 1;
    }
}