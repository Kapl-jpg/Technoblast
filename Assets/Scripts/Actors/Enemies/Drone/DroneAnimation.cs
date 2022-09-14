using UnityEngine;
using Zenject;

public class DroneAnimation : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Close = Animator.StringToHash("Close");
    private static readonly int Open = Animator.StringToHash("Open");

    [SerializeField] private float maxDistance=10;
    [SerializeField] private bool drawSphere;
    [SerializeField] private bool debug;

    private CharacterMovement _characterMovement;

    [Inject]
    public void Construct(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _characterMovement.transform.position);
        
        if (distance <= maxDistance)
            SetOpen();
        else
            SetClose();
    }

    private void SetClose()
    {
        _animator.SetBool(Close, true);
        _animator.SetBool(Open, false);
    }

    private void SetOpen()
    {
        _animator.SetBool(Open, true);
        _animator.SetBool(Close, false);
    }

    private void OnDrawGizmos()
    {
        if (!drawSphere)
            return;

        if (_characterMovement == null) return;

        Debug.DrawLine(transform.position, _characterMovement.transform.position,
            Vector3.Distance(transform.position, _characterMovement.transform.position) <= maxDistance
                ? Color.red
                : Color.blue);
    }
}
