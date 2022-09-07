using System;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Directors.UI
{
    public class GlobalDeathCounter : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        
        private void Start()
        {
            var deathCounter = _levelData.GetLevelStateData.GlobalDeathCounter;
            
            GetComponent<TextMeshProUGUI>().text = $"{deathCounter}";
        }
    }
}