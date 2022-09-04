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

    [Header("Sound Sources"), Space(20)]
    [SerializeField] private AudioClip _cyanAudioClip;
    [SerializeField] private AudioClip _greyAudioClip;
    [SerializeField] private AudioClip _purpleAudioClip;
    [SerializeField] private AudioClip _orangeAudioClip;

    public JumpableObjectData GetData(ForceColor color)
    {
        switch (color)
        {
            case(ForceColor.Cyan):
                return new JumpableObjectData(ForceColor.Cyan, _cyanColorForce, _cyanColorMaterial, _cyanAudioClip);
            case(ForceColor.Grey):
                return new JumpableObjectData(ForceColor.Grey, _greyColorForce, _greyColorMaterial, _greyAudioClip);
            case(ForceColor.Orange):
                return new JumpableObjectData(ForceColor.Orange, _orangeColorForce, _orangeColorMaterial, _orangeAudioClip);
            case(ForceColor.Purple):
                return new JumpableObjectData(ForceColor.Purple, _purpleColorForce, _purpleColorMaterial, _purpleAudioClip);
            default:
                return null;
        }
    }
}
