using Directors.UI;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class FinalText : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private FinalStat _statToShow;
        
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

        SetText();
    }

    private void SetText()
    {
        var globalData = _levelData.GetLevelStateData; 
        var textToSet = "";

        switch (_statToShow)
        {
            case(FinalStat.Death):
                textToSet = globalData.GlobalDeathCounter.ToString();
                break;
            case(FinalStat.Cans):
                textToSet = globalData.SprayCanCounter.ToString() + "/50";
                break;
            case(FinalStat.Time):
                var updateTimer = new UpdateTimerUI();
                textToSet = updateTimer.GetStringInTimeFormatWithHours(Mathf.RoundToInt(globalData.GlobalGameTimer));
                break;
        }
            
        _text.text = textToSet;
    }
}
public enum FinalStat {Death, Time, Cans }