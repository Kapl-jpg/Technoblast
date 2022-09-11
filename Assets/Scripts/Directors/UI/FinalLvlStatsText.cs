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
            var globalSprayCans = globalData.SprayCanCounter;
            
            var updateTimer = new UpdateTimerUI();
            var globalTime = updateTimer.GetStringInTimeFormatWithHours(Mathf.RoundToInt(globalData.GlobalGameTimer));

            _text.text = $"Общее время прохождения - {globalTime} \n " +
                         $"Общее количество смертей - {globalDeath} \n " +
                         $"Всего собрано граффити - {globalSprayCans} из {_levelData.SprayCanInAllLevels}";
        }
    }
}