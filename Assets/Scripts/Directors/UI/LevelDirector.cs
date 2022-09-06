using Data;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Directors.UI
{
    public class LevelDirector : MonoBehaviour
    {
        [SerializeField] private GlobalGameTimer _timer;
        [SerializeField] private GlobalSprayCanCounter _sprayCanCounter;
        
        [SerializeField] private LevelData _levelData;
        
        private LevelStateData _levelStateData;
        
        [Inject]
        private void Construct(ILevelEnd levelEnd, ICanDie playerDie)
        {
            levelEnd.OnLevelEndEvent += SaveLevelEndValues;
            playerDie.OnDeathEvent += SaveTimerValue;
        }
        
        private void Start()
        {
            SetStartLevelData();
        }
        
        private void SetStartLevelData()
        {
            _levelStateData = _levelData.GetLevelStateData;

            _timer.CurrentTimerValue = _levelStateData.GlobalGameTimer;
            _sprayCanCounter.CurrentSprayCanCounter = _levelStateData.SprayCanCounter;
        }
        
        private void SaveLevelEndValues()
        {
            _levelData.SetLevelStateData(new LevelStateData(_sprayCanCounter.CurrentSprayCanCounter, _timer.CurrentTimerValue));
        }
        
        private void SaveTimerValue()
        {
            _levelData.SetLevelStateData(new LevelStateData(_levelStateData.SprayCanCounter, _timer.CurrentTimerValue));
        }
    }
}