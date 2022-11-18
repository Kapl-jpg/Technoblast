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

    [SerializeField] private Light[] lights;
    [SerializeField, ColorUsage(false,false)] private Color greenColorLight;
    [SerializeField, ColorUsage(false,false)] private Color redColorLight;

    private Color _lightColor;
    private Material _emissionMaterial;
    private Material _quadMaterial;
    
    private void Start()
    {
        switch (stageLevel)
        {
            case StageLevel.Start:
                _emissionMaterial = redEmission;
                _quadMaterial = redQuadMaterial;
                _lightColor = redColorLight;
                break;
            case StageLevel.End:
                _emissionMaterial = greenEmission;
                _quadMaterial = greenQuadMaterial;
                _lightColor = greenColorLight;
                break;
        }

        ChangeQuadColor(_quadMaterial);
        ChangeEmissionElements(_emissionMaterial);
        ChangeLight(_lightColor);
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

    private void ChangeLight(Color currentColor)
    {
        foreach (var light in lights)
        {
            light.GetComponent<Light>().color = currentColor;
        }
    }
}

public enum StageLevel
{
    Start,
    End
}
