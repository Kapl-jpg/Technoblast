using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ScriptableObjects/ColorConfigs", order = 1)]

public class ColorForceConfig : ScriptableObject
{
    [Header("Force Values")]
    [SerializeField] private int _cyanColorForce;
    [SerializeField] private int _greyColorForce;
    [SerializeField] private int _purpleColorForce;
    [SerializeField] private int _orangeColorForce;

    [Header("Material Values"), Space(20)]
    [SerializeField] private Material _cyanColorMaterial;
    [SerializeField] private Material _greyColorMaterial;
    [SerializeField] private Material _purpleColorMaterial;
    [SerializeField] private Material _orangeColorMaterial;
    [SerializeField] private Material _redColorMaterial;

    [Header("Sound Sources"), Space(20)]
    [SerializeField] private AudioClip[] _cyanAudioClip;
    [SerializeField] private AudioClip[] _greyAudioClip;
    [SerializeField] private AudioClip[] _purpleAudioClip;
    [SerializeField] private AudioClip[] _orangeAudioClip;

    [Header("ColorWave"), Space(20)]
    [SerializeField] [ColorUsage(true,true)] private Color _cyanWaveColor;
    [SerializeField] [ColorUsage(true,true)] private Color _greyWaveColor;
    [SerializeField] [ColorUsage(true,true)] private Color _purpleWaveColor;
    [SerializeField] [ColorUsage(true,true)] private Color _orangeWaveColor;
    
    public JumpableObjectData GetData(ForceColor color)
    {
        switch (color)
        {
            case ForceColor.Cyan:
                return new JumpableObjectData(_cyanColorForce, _cyanColorMaterial, _cyanAudioClip,_cyanWaveColor);
            case ForceColor.Grey:
                return new JumpableObjectData(_greyColorForce, _greyColorMaterial, _greyAudioClip,_greyWaveColor);
            case ForceColor.Orange:
                return new JumpableObjectData(_orangeColorForce, _orangeColorMaterial, _orangeAudioClip, _orangeWaveColor);
            case ForceColor.Purple:
                return new JumpableObjectData(_purpleColorForce, _purpleColorMaterial, _purpleAudioClip, _purpleWaveColor);
            case ForceColor.Red:
                return new JumpableObjectData(_greyColorForce, _redColorMaterial, _greyAudioClip, _greyWaveColor);
            default:
                return null;
        }
    }
}