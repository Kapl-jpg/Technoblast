using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private float minDelayTime;
    [SerializeField] private float maxDelayTime;
    [SerializeField] private float shutdownTime;
    [SerializeField] private Material newMaterial;
    [SerializeField] private List<MeshRenderer> currentMeshes;
    
    private List<Material> _defaultMaterial;

    private float _currentTime;

    private void Start()
    {
        _defaultMaterial = new List<Material>();

        CreatePoolDefaultMaterials();
        LaunchFlicking();
    }

    private void CreatePoolDefaultMaterials()
    {
        foreach (var mesh in currentMeshes)
        {
            _defaultMaterial.Add(mesh.sharedMaterial);
        }
    }
    private void LaunchFlicking()
    {
        for (var i = 0; i < currentMeshes.Count; i++)
        {
            StartCoroutine(Timer(currentMeshes[i], _defaultMaterial[i]));
        }
    }

    private IEnumerator Timer(MeshRenderer currentMesh, Material defaultMaterial)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelayTime, maxDelayTime));
            
            currentMesh.sharedMaterial = newMaterial;
            
            yield return new WaitForSeconds(shutdownTime);

            currentMesh.sharedMaterial = defaultMaterial;
        }
    }
}