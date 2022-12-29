using UnityEngine;

public class SortMeshRendererLayer : MonoBehaviour
{
    [SerializeField] private int layerNumber;
    private MeshRenderer _meshRenderer;
    
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.sortingOrder = layerNumber;
    }
}
