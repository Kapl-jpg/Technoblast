using System;
using System.Collections;
using Player.Interactables;
using UnityEngine;

[RequireComponent( typeof(Collider))]
public class Door : OpenableActor
{
    [SerializeField] private GameObject[] doorEmissionElement;
    [SerializeField] private GameObject[] buttonEmissionElements;
    
    [SerializeField] private Material redNeonMaterial;
    [SerializeField] private Material greenNeonMaterial;

    private Material[] _doorMaterial;
    private Material[] _buttonMaterials;

    private Collider _collider;
    public event Action OnDoorOpenEvent;
    public event Action OnDoorCloseEvent;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        
        _doorMaterial = GetMaterial(doorEmissionElement,_doorMaterial);
        _buttonMaterials = GetMaterial(buttonEmissionElements, _buttonMaterials);
    }

    private Material[] GetMaterial(GameObject[] currentObjects, Material[] currentMaterial)
    {
        currentMaterial = new Material[currentObjects.Length];
        for (var i = 0; i < currentObjects.Length; i++)
        {
            currentMaterial[i] = currentObjects[i].GetComponent<Renderer>().material;
        }

        return currentMaterial;
    }

    public override void OpenOnTime(float time)
    {
        StartCoroutine(OpenOnTimeAsync(time));
    }

    private IEnumerator OpenOnTimeAsync(float time)
    {
        Open();
        yield return new WaitForSeconds(time);
        Close();
    }

    public override void Open()
    {
        OnDoorOpenEvent?.Invoke();
        EnableCollider(false);
        SetNewMaterial(doorEmissionElement,greenNeonMaterial);
        SetNewMaterial(buttonEmissionElements,redNeonMaterial);
    }
    
    private void Close()
    {
        OnDoorCloseEvent?.Invoke();
        EnableCollider(true);
        SetNewMaterial(doorEmissionElement,redNeonMaterial);
        SetNewMaterial(buttonEmissionElements,greenNeonMaterial);
    }
    
    private void EnableCollider(bool state)
    {
        _collider.enabled = state;
    }
    
    private void SetNewMaterial(GameObject[] currentEmissionElement, Material nextMaterial)
    {
        foreach (var element in currentEmissionElement)
        {
            element.GetComponent<Renderer>().material = nextMaterial;
        }
    }
}
