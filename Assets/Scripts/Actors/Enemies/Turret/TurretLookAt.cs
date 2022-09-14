using UnityEngine;
using Zenject;

public class TurretLookAt : MonoBehaviour
{
    private CharacterMovement _characterMovement;

    [SerializeField] private GameObject movingPart;



    [Inject]
    private void Construct(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }

    private void Start()
    {

    }

    private void Update()
    {
        movingPart.transform.LookAt(
            new Vector3(_characterMovement.transform.position.x, _characterMovement.transform.position.y,
                transform.position.z), Vector3.back);
    }
}
