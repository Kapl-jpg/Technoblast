using System.Collections;
using Interfaces;
using UnityEngine;

public class DoorAndKey : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] private bool _haveTimer;
    [SerializeField] private float _timeWhileDoorIsOpen;

    [Header("Reference on Door object"),Space(10)]
    [SerializeField] private GameObject _door;
    
    public bool IsActive => true;

    public void Interact()
    {
        if (_haveTimer)
            UnlockDoor();
        else
            StartCoroutine(OpenDoorOnATime(_timeWhileDoorIsOpen));
    }

    private IEnumerator OpenDoorOnATime(float time)
    {
        UnlockDoor();

        yield return new WaitForSeconds(time);
        
        LockDoor();
    }

    private void UnlockDoor()
    {
        
    }
    
    private void LockDoor()
    {
        
    }
}
