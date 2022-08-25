using UnityEngine;

public class PlatformForce : MonoBehaviour
{
    [SerializeField] protected ColorForceConfig _colorForceConfig;
    [SerializeField] protected ForceColor _color;

    protected int _force;

    private void Start()
    {
        Init();
    }

    protected void Init()
    {
        _force = _colorForceConfig.GetForceByColor(_color);
    }
    
    public int GetForce()
    {
        return _force;
    }
}
