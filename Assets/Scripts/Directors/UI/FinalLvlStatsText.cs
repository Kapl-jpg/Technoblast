using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Directors.UI
{
    public class FinalLvlStatsText : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        
        private TextMeshProUGUI _text;
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            
            SetText();
        }

        private void SetText()
        {
            var globalData = _levelData.GetLevelStateData;
            
            var globalDeath = globalData.GlobalDeathCounter;
            var globalTime = Mathf.Round(globalData.GlobalGameTimer);
            var globalSprayCans = globalData.SprayCanCounter;

            _text.text = $"Общее время прохождения - {globalTime} \n " +
                         $"Общее количество смертей - {globalDeath} \n " +
                         $"Всего собрано граффити - {globalSprayCans}";
        }
    }
}