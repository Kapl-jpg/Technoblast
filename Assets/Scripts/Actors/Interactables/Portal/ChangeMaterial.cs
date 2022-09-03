using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material _levelEndPortalMaterial;
    [SerializeField] private MeshRenderer _emisElementMeshRenderer;

    private void Start()
    {
        _emisElementMeshRenderer.material = _levelEndPortalMaterial;
    }
}
