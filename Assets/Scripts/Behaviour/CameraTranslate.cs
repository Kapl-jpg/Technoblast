using UnityEngine;
using Zenject;

public class CameraTranslate : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    private GameObject character;

    [Inject]
    private void Construct(CharacterMovement characterMovement)
    {
        character = characterMovement.gameObject;
    }

    private void Start()
    {
        transform.position = character.transform.position + offset;
    }

    private void Update()
    {
        transform.position = character.transform.position + offset;
    }

}
