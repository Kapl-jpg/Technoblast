using UnityEngine;

public class TurretLookAt : MonoBehaviour
{

    [SerializeField] private GameObject movingPart;

    public void LookAtCharacter(GameObject characterMovement)
    {
        movingPart.transform.LookAt(characterMovement.transform.position, Vector3.back);
    }
}
