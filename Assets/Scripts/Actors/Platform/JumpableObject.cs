using UnityEngine;

public abstract class JumpableObject : MonoBehaviour, IJumpableObject
{
    [SerializeField] protected ColorForceConfig _colorForceConfig;
    [SerializeField] protected ForceColor _color;
    [SerializeField] protected MeshRenderer[] _emissionElementMeshRenderer;

    protected JumpableObjectData _objectData;
    
    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _objectData = _colorForceConfig.GetData(_color);
        SetColor();
    }

    private void SetColor()
    {
        if (_emissionElementMeshRenderer == null) return;
        
        foreach (var meshRenderer in _emissionElementMeshRenderer)
        {
            meshRenderer.material = _objectData.ObjectMaterial;
        }
    }
    
    public JumpableObjectData GetData()
    {
        return _objectData;
    }
}
