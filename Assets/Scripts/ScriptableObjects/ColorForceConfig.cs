using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ScriptableObjects/ColorConfigs", order = 1)]

public class ColorForceConfig : ScriptableObject
{
    [SerializeField] private int _cianColorForce;
    public int CianColorForce => _cianColorForce;
    
    
    [SerializeField] private int _greyColorForce;
    public int GreyColorForce => _greyColorForce;
    
    
    [SerializeField] private int _purpleColorForce;
    public int PurpleColorForce => _purpleColorForce;
    
    
    [SerializeField] private int _orangeColorForce;
    public int OrangeColorForce => _orangeColorForce;

    public int GetForceByColor(ForceColor color)
    {
        return GetForce(color);
    }

    private int GetForce(ForceColor color)
    {
        switch (color)
        {
            case(ForceColor.Cian):
                return CianColorForce;
            case(ForceColor.Grey):
                return GreyColorForce;
            case(ForceColor.Orange):
                return OrangeColorForce;
            case(ForceColor.Purple):
                return PurpleColorForce;
            default:
                return 0;
        }
    }
}
