using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private float minDelayTime;
    [SerializeField] private float maxDelayTime;
    [SerializeField] private float shutdownTime;
    [SerializeField] private Material newMaterial;
    [SerializeField] private List<MeshRenderer> currentMesh;

    private List<Material> _defaultMaterial;
    
    private float _currentTime;

    private void Start()
    {
        _defaultMaterial = new List<Material>();
        
        foreach (var mesh in currentMesh)
        {
            _defaultMaterial.Add(mesh.sharedMaterial);
        }
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelayTime, maxDelayTime));

            foreach (var mesh in currentMesh)
            {
                mesh.sharedMaterial = newMaterial;
            }

            yield return new WaitForSeconds(shutdownTime);
            
            for (var i = 0; i < currentMesh.Count; i++)
            {
                currentMesh[i].sharedMaterial = _defaultMaterial[i];
            }
        }
    }
}
