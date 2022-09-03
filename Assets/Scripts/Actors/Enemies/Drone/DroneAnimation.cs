using UnityEngine;

public class DroneAnimation : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Close = Animator.StringToHash("Close");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Open = Animator.StringToHash("Open");

    private void Start()
    {
        
    }
}
