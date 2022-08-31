using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ScriptableObjects/ColorConfigs", order = 1)]

public class ColorForceConfig : ScriptableObject
{
    [SerializeField] private int _cyanColorForce;
    public int CyanColorForce => _cyanColorForce;
    
    
    [SerializeField] private int _greyColorForce;
    public int GreyColorForce => _greyColorForce;
    
    
    [SerializeField] private int _purpleColorForce;
    public int PurpleColorForce => _purpleColorForce;
    
    
    [SerializeField] private int _orangeColorForce;
    public int OrangeColorForce => _orangeColorForce;

    [SerializeField] private Material _cyanColorMaterial;
    public Material CyanColorMaterial => _cyanColorMaterial;
    
    [SerializeField] private Material _greyColorMaterial;
    public Material GreyColorMaterial => _greyColorMaterial;

    [SerializeField] private Material _purpleColorMaterial;
    public Material PurpleColorMaterial => _purpleColorMaterial;

    [SerializeField] private Material _orangeColorMaterial;
    public Material OrangeColorMaterial => _orangeColorMaterial;

    public int GetForceByColor(ForceColor color)
    {
        return GetForce(color);
    }

    private int GetForce(ForceColor color)
    {
        switch (color)
        {
            case(ForceColor.Cyan):
                return CyanColorForce;
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

    public Material GetMaterialByColor(ForceColor color)
    {
        return GetMaterial(color);
    }

    private Material GetMaterial(ForceColor color)
    {
        switch (color)
        {
            case (ForceColor.Cyan):
                return CyanColorMaterial;
            case (ForceColor.Grey):
                return GreyColorMaterial;
            case (ForceColor.Orange):
                return OrangeColorMaterial;
            case (ForceColor.Purple):
                return PurpleColorMaterial;
            default:
                return null;
        }
    }
}
