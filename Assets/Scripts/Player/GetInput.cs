using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(SoundWave))]
public class GetInput : MonoBehaviour
{
    private CharacterMovement _characterMovement;

    private SoundWave _soundWave;

    [Inject]
    private void Construct(CharacterMovement characterMovement,SoundWave soundWave)
    {
        _characterMovement = characterMovement;
        _soundWave = soundWave;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            _characterMovement.Run(Vector3.left);

        if (Input.GetKey(KeyCode.D))
            _characterMovement.Run(Vector3.right);

        if (Input.GetKeyDown(KeyCode.W))
            _characterMovement.Jump();

        if(_characterMovement.IsGrounded())
            return;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _soundWave.Flight(Vector3.left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _soundWave.Flight(Vector3.right);
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
            _soundWave.Flight(Vector3.down);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _soundWave.Flight(Vector3.up);
    }
}
