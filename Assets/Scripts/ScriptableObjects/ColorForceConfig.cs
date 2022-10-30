using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ScriptableObjects/ColorConfigs", order = 1)]

public class ColorForceConfig : ScriptableObject
{
    [Header("Force Values")]
    [SerializeField] private int cyanColorForce;
    [SerializeField] private int greyColorForce;
    [SerializeField] private int purpleColorForce;
    [SerializeField] private int orangeColorForce;

    [Header("Material Values"), Space(20)]
    [SerializeField] private Material cyanColorMaterial;
    [SerializeField] private Material greyColorMaterial;
    [SerializeField] private Material purpleColorMaterial;
    [SerializeField] private Material orangeColorMaterial;
    [SerializeField] private Material redColorMaterial;

    [Header("Sound Sources"), Space(20)]
    [SerializeField] private AudioClip[] cyanAudioClip;
    [SerializeField] private AudioClip[] greyAudioClip;
    [SerializeField] private AudioClip[] purpleAudioClip;
    [SerializeField] private AudioClip[] orangeAudioClip;

    [Header("Color Wave"), Space(20)]
    [SerializeField] [ColorUsage(true,true)] private Color cyanWaveColor;
    [SerializeField] [ColorUsage(true,true)] private Color greyWaveColor;
    [SerializeField] [ColorUsage(true,true)] private Color purpleWaveColor;
    [SerializeField] [ColorUsage(true,true)] private Color orangeWaveColor;
    
    public JumpableObjectData GetData(ForceColor color)
    {
        switch (color)
        {
            case(ForceColor.Cyan):
                return new JumpableObjectData(cyanColorForce, cyanColorMaterial, cyanAudioClip,cyanWaveColor);
            case(ForceColor.Grey):
                return new JumpableObjectData(greyColorForce, greyColorMaterial, greyAudioClip,greyWaveColor);
            case(ForceColor.Orange):
                return new JumpableObjectData(orangeColorForce, orangeColorMaterial, orangeAudioClip, orangeWaveColor);
            case(ForceColor.Purple):
                return new JumpableObjectData(purpleColorForce, purpleColorMaterial, purpleAudioClip, purpleWaveColor);
            case ForceColor.Red:
                return new JumpableObjectData(greyColorForce, redColorMaterial, greyAudioClip, greyWaveColor);
            default:
                return null;
        }
    }
}