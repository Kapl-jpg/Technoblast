using Data;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Directors.UI
{
    public class LevelDirector : MonoBehaviour
    {
        [SerializeField] private GlobalGameTimer _timer;
        [SerializeField] private GlobalSprayCanCounter _sprayCanCounter;
        [SerializeField] private GlobalDeathCounter _deathCounter;
        
        [SerializeField] private StatSaver _statSaver;

        private LevelStateData _levelStateData;
        private DataFile _dataFile;
        
        [Inject]
        private void Construct(ILevelEnd levelEnd, ICanDie playerDie,DataFile dataFile)
        {
            levelEnd.OnLevelEndEvent += SaveLevelEndValues;
            playerDie.OnDeathEvent += SaveTimerValue;
            _dataFile = dataFile;
        }
        
        private void Awake()
        {
            SetStartLevelData();
        }
        
        private void SetStartLevelData()
        {
            _levelStateData = _statSaver.GetLevelData();

            _timer.CurrentTimerValue = _levelStateData.GlobalGameTimer;
            _sprayCanCounter.CurrentSprayCanCounter = _levelStateData.SprayCanCounter;
        }
        
        public void SaveLevelEndValues()
        {
            _dataFile.WriteSprayCount(_sprayCanCounter.CurrentSprayCanCounter);
            _statSaver.SaveLevelStateData(new LevelStateData(_sprayCanCounter.CurrentSprayCanCounter, _timer.CurrentTimerValue, _levelStateData.GlobalDeathCounter));
        }
        
        public void SaveTimerValue()
        {
            _statSaver.SaveLevelStateData(new LevelStateData(_levelStateData.SprayCanCounter, _timer.CurrentTimerValue, ++_levelStateData.GlobalDeathCounter));
        }
    }
}