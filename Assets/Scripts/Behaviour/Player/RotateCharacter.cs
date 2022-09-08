using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    [SerializeField] private Transform currentTransform;

    private InputHandler _inputHandler;

    private void Start()
    {
        _inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        if (_inputHandler.Movement < 0)
        {
            currentTransform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (_inputHandler.Movement > 0)
        {
            currentTransform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
