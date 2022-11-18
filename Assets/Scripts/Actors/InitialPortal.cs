using UnityEngine;

public class InitialPortal : MonoBehaviour
{
    [SerializeField] private StageLevel stageLevel;
    [SerializeField] private Material greenQuadMaterial;
    [SerializeField] private Material redQuadMaterial;
    [SerializeField] private GameObject portalQuad;

    [SerializeField] private GameObject[] emissionElements;
    [SerializeField] private Material greenEmission;
    [SerializeField] private Material redEmission;

    private Material _emissionMaterial;
    private Material _quadMaterial;
    private void Start()
    {
        switch (stageLevel)
        {
            case StageLevel.Start:
                _emissionMaterial = redEmission;
                _quadMaterial = redQuadMaterial;
                break;
            case StageLevel.End:
                _emissionMaterial = greenEmission;
                _quadMaterial = redQuadMaterial;
                break;
        }

        ChangeQuadColor(_quadMaterial);
        ChangeEmissionElements(_emissionMaterial);
    }

    private void ChangeQuadColor(Material quadMaterial)
    {
        portalQuad.GetComponent<MeshRenderer>().sharedMaterial = quadMaterial;
    }

    private void ChangeEmissionElements(Material emissionMaterial)
    {
        foreach (var emissionElement in emissionElements)
        {
            emissionElement.GetComponent<MeshRenderer>().sharedMaterial = emissionMaterial;
        }
    }
}

public enum StageLevel
{
    Start,
    End
}
