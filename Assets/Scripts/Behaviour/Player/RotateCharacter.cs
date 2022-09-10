using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    [SerializeField] private Transform currentTransform;

    public void SetRotate(int directionX)
    {
        if (directionX == -1)
            RotateLeft();
        if (directionX == 1)
            RotateRight();
    }

    private void RotateRight()
    {
        currentTransform.rotation = Quaternion.Euler(0, 90, 0);
    }

    private void RotateLeft()
    {
        currentTransform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
