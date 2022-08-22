using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody currentRigidbody;

    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    
    [SerializeField] private float distanceToGround;

    [Tooltip("Drawn on scene")]
    [SerializeField] private bool drawDistanceBeforeGround = true;

    public void Run(Vector3 direction)
    {
        currentRigidbody.AddForce(direction * speed, ForceMode.Force);
        currentRigidbody.velocity = new Vector3(Mathf.Clamp(currentRigidbody.velocity.x, -speed, speed),
            currentRigidbody.velocity.y);

    }

    public void Jump()
    {
        if(IsGrounded())
            currentRigidbody.velocity = new Vector3(currentRigidbody.velocity.x,forceJump);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }

    private void OnDrawGizmos()
    {
        if(!drawDistanceBeforeGround)
            return;
        var position = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, new Vector3(position.x,position.y - distanceToGround));
    }
}
