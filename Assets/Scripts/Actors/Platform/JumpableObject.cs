using UnityEngine;

public abstract class JumpableObject : MonoBehaviour, IHaveJumpForce
{
    [SerializeField] protected ColorForceConfig _colorForceConfig;
    [SerializeField] protected ForceColor _color;
    [SerializeField] protected MeshRenderer[] _emissionElementMeshRenderer;
    
    protected int _force;
    protected Material _material;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _force = _colorForceConfig.GetForceByColor(_color);
        _material = _colorForceConfig.GetMaterialByColor(_color);
        SetColor();
    }

    private void SetColor()
    {
        foreach (MeshRenderer meshRenderer in _emissionElementMeshRenderer)
        {
            meshRenderer.material = _colorForceConfig.GetMaterialByColor(_color);
        }
    }
    
    public virtual int GetForce()
    {
        return _force;
    }
}
