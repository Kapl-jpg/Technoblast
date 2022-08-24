using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ScriptableObjects/ColorConfigs", order = 1)]

public class ColorForceConfig : ScriptableObject
{
    [SerializeField] private int _blueColorForce;
    public int BlueColorForce => _blueColorForce;
    
}
