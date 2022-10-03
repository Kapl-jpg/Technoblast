using UnityEngine;

public class BoxColliderGetCast : MonoBehaviour
{ 
    [SerializeField] private Direction directionEnum;
    [SerializeField] private SoundWave wave;

    private IJumpableObject jumpableObjectData;
    private Vector3 direction;
    private bool hit;

    private void Start()
    {
        switch (directionEnum)
        {
            case Direction.Up:
                direction = Vector3.up;
                break;
            case Direction.Down:
                direction = Vector3.down;
                break;
            case Direction.Left:
                direction = Vector3.left;
                break;
            case Direction.Right:
                direction = Vector3.right;
                break;
        }
    }

    public void LaunchWave()
    {
        wave.Flight(direction, hit , jumpableObjectData);
    }

    private void OnTriggerStay(Collider other)
    {
            if (other.TryGetComponent<IJumpableObject>(out var objectData))
            {
                jumpableObjectData = objectData;
                hit = true;
            }        
    }

    private void OnTriggerExit(Collider other)
    {
        hit = false;
    }
}

public enum Direction
{
    Up,
    Left,
    Right,
    Down
};
