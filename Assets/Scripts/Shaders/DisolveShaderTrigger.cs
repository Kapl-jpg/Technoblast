using System.Collections;
using UnityEngine;

public class DisolveShaderTrigger : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float _startDisolveValue;
    [SerializeField] private float _endDisolveValue;
    
    [Header("References"),Space(10)]
    [SerializeField] private AnimationsEvents _animationsEvents;
    [SerializeField] private Material _materialToSet;
    [SerializeField] private GameObject _meshObject;
    
    private readonly string _propertyName = "DisolveTime";
    private Material[] materialsInMesh;
    private void Start()
    {
        _animationsEvents.OnDeathStartEvents += ChangeMaterialAndStartDisolve;
    }

    private void OnDestroy()
    {
        _animationsEvents.OnDeathStartEvents -= ChangeMaterialAndStartDisolve;
    }

    private void ChangeMaterialAndStartDisolve()
    {
        SetNewMaterial(_materialToSet);
        StartCoroutine(StartDisolveAsync());
    }

    private void SetNewMaterial(Material material)
    {
        materialsInMesh = _meshObject.GetComponent<SkinnedMeshRenderer>().materials;
        _meshObject.GetComponent<SkinnedMeshRenderer>().sortingOrder = 15;
        
        for (int i = 0; i < materialsInMesh.Length; i++)
        {
            materialsInMesh[i] = material;
        }

        _meshObject.GetComponent<SkinnedMeshRenderer>().materials = materialsInMesh;
    }
    
    private IEnumerator StartDisolveAsync()
    {
        _materialToSet.SetFloat(_propertyName,_startDisolveValue);
        var startValue = _startDisolveValue;
        
        while (_materialToSet.GetFloat(_propertyName) > _endDisolveValue)
        {
            startValue -= 0.1f;
            _materialToSet.SetFloat(_propertyName,startValue);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
