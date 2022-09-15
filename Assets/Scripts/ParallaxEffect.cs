using UnityEngine;
using Zenject;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] ratio;
    [SerializeField] private Vector3 offset;

    private CharacterMovement _characterMovement;

    [Inject]
    private void Construct(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }
    
    void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            var position = _characterMovement.transform.position;
            layers[i].position = new Vector3(position.x * ratio[i] + offset.x, position.y * ratio[i] + offset.y, offset.z);
        }
    }
}
