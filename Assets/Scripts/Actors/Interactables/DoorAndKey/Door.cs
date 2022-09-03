using System.Collections;
using Player.Interactables;
using UnityEngine;

[RequireComponent( typeof(Collider))]
public class Door : OpenableActor, ICanBePaused
{
    [SerializeField] private Material _openMaterial;

    [SerializeField] private GameObject _latticeReference;
    
    public bool IsPaused { get; }

    private Collider _collider;

    private Material _latticeMaterial;
    
    private Material _defaultMaterial;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _defaultMaterial =_latticeReference.GetComponent<Renderer>().material;
    }

    public override void Open()
    {
        _collider.isTrigger = true;
        SetNewMaterial(_openMaterial);
    }

    public override void OpenOnTime(float time)
    {
        StartCoroutine(OpenOnTimeAsync(time));
    }

    private IEnumerator OpenOnTimeAsync (float time)
    {
        Open();
        yield return new WaitForSeconds(time);
        Close();
    }

    private void Close()
    {
        _collider.isTrigger = false;
        SetNewMaterial(_defaultMaterial);
    }
    
    private void SetNewMaterial(Material material)
    {
        _latticeReference.GetComponent<Renderer>().material = material;
    }
    
    public void Pause()
    {
        throw new System.NotImplementedException();
    }

    public void Unpause()
    {
        throw new System.NotImplementedException();
    }
}
