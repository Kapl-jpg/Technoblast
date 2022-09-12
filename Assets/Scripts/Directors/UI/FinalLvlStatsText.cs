using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Directors.UI
{
    public class FinalLvlStatsText : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private int _skullIconSize;

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
            var updateTimer = new UpdateTimerUI();
            var globalTime = updateTimer.GetStringInTimeFormatWithHours(Mathf.RoundToInt(globalData.GlobalGameTimer));

            _text.text = $"Общее время прохождения - {globalTime} \n " +
                         $"Общее количество смертей    <size={_skullIconSize}><sprite=0></size>- {globalDeath}";
        }
    }
}