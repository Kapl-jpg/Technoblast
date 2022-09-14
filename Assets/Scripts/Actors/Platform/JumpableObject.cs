using UnityEngine;

public abstract class JumpableObject : MonoBehaviour, IJumpableObject
{
    [SerializeField] protected ColorForceConfig _colorForceConfig;
    [SerializeField] protected ForceColor _color;
    [SerializeField] protected MeshRenderer[] _emissionElementMeshRenderer;

    public JumpableObjectData ObjectData
    {
        get
        {
            if(_objectData == null)
                _objectData = _colorForceConfig.GetData(_color);
            return _objectData;
        }
    }

    protected JumpableObjectData _objectData;
    
    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
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
