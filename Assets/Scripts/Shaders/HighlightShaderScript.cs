using System.Collections;
using UnityEngine;

public class HighlightShaderScript : MonoBehaviour
{
    [SerializeField] private TrickMove _trickMove;
    [SerializeField] private GameObject _objectWithMaterial;

    private Material _hightigthMaterial;
    private float _hightlightTime;
    private static readonly int Trick = Shader.PropertyToID("_Trick");

    private void Start()
    {
        var materials = _objectWithMaterial.GetComponent<SkinnedMeshRenderer>().sharedMaterials;
        _hightigthMaterial = materials[materials.Length - 1];
        SetMaterialPower(0);
        _hightlightTime = _trickMove.InvincibilityTime;
        _trickMove.OnTrickStartEvent += HighlightMaterial;
    }

    private void SetMaterialPower(float value)
    {
        _hightigthMaterial.SetFloat(Trick, value);
    }
    
    private void HighlightMaterial()
    {
        StartCoroutine(HighlightMaterialAsync());
    }

    private IEnumerator HighlightMaterialAsync()
    {
        SetMaterialPower(1);
        yield return new WaitForSeconds(_hightlightTime);
        SetMaterialPower(0);
    }
}
