using System;
using System.Collections;
using Player.Interactables;
using UnityEngine;

[RequireComponent( typeof(Collider))]
public class Door : OpenableActor
{
    [SerializeField] private Material _openMaterial;
    [SerializeField] private GameObject _latticeReference;

    private Collider _collider;
    private Material _latticeMaterial;
    private Material _defaultMaterial;

    public event Action OnDoorOpenEvent;
    public event Action OnDoorCloseEvent;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _defaultMaterial =_latticeReference.GetComponent<Renderer>().material;
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
        SetNewMaterial(_openMaterial);
    }
    
    private void Close()
    {
        OnDoorCloseEvent?.Invoke();
        EnableCollider(true);
        SetNewMaterial(_defaultMaterial);
    }
    
    private void EnableCollider(bool state)
    {
        _collider.enabled = state;
    }
    
    private void SetNewMaterial(Material material)
    {
        _latticeReference.GetComponent<Renderer>().material = material;
    }
}
