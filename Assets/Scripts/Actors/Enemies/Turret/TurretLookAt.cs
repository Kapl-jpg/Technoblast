using UnityEngine;

public class TurretLookAt : MonoBehaviour
{

    [SerializeField] private GameObject movingPart;

    public void LookAtCharacter(GameObject characterMovement)
    {
        var distance = Vector3.Distance(transform.position, movingPart.transform.position);
        
        movingPart.transform.LookAt(characterMovement.transform.position, Vector3.back);
    }
}
