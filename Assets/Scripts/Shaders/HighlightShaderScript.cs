using System.Collections;
using UnityEngine;

public class HighlightShaderScript : MonoBehaviour
{
    [SerializeField] private TrickMove _trickMove;
    [SerializeField] private GameObject _objectWithMaterial;
    [SerializeField] private float _defaultHightlightValue;
    [SerializeField] private float _trickHightLightValue;

    private readonly string _powerPropertyName = "_Power";
    private Material _hightigthMaterial;
    private float _hightlightTime;
    
    private void Start()
    {
        _hightigthMaterial = _objectWithMaterial.GetComponent<Renderer>().sharedMaterial;
        SetMaterialPower(_defaultHightlightValue);
        _hightlightTime = _trickMove.InvincibilityTime;
        _trickMove.OnTrickStartEvent += HighlightMaterial;
    }

    private void SetMaterialPower(float value)
    {
        _hightigthMaterial.SetFloat(_powerPropertyName, value);
    }
    
    private void HighlightMaterial()
    {
        StartCoroutine(HighlightMaterialAsync());
    }

    private IEnumerator HighlightMaterialAsync()
    {
        SetMaterialPower(_trickHightLightValue);
        yield return new WaitForSeconds(_hightlightTime);
        SetMaterialPower(_defaultHightlightValue);
    }
}
