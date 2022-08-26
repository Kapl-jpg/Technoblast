using UnityEngine;

public abstract class JumpableObject : MonoBehaviour, IHaveJumpForce
{
    [SerializeField] protected ColorForceConfig _colorForceConfig;
    [SerializeField] protected ForceColor _color;

    protected int _force;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _force = _colorForceConfig.GetForceByColor(_color);
    }
    
    public virtual int GetForce()
    {
        return _force;
    }
}
