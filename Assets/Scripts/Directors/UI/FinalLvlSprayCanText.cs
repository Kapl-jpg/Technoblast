using System.Collections;
using System.Collections.Generic;
using Directors.UI;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class FinalLvlSprayCanText : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private int _sprayCanIconSize;
    
    private TextMeshProUGUI _text;
        
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
            
        SetText();
    }

    private void SetText()
    {
        var globalData = _levelData.GetLevelStateData;
        var globalSprayCans = globalData.SprayCanCounter;
        
        _text.text = $"Всего собрано граффити  <size={_sprayCanIconSize}><sprite=0></size>- {globalSprayCans} из {_levelData.SprayCanInAllLevels}";
    }
}
