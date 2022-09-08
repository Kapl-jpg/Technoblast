using Data;
using ScriptableObjects;
using UnityEngine;

namespace Directors
{
    public class StatSaver : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        
        private LevelStateData _levelStateData;

        public LevelStateData GetLevelData()
        {
            return _levelData.GetLevelStateData;
        }

        public void SaveLevelStateData(LevelStateData newLevelStateData)
        {
            _levelData.SetLevelStateData(newLevelStateData);
        }

        public void ClearLevelStateData()
        {
            _levelData.SetLevelStateData( new LevelStateData());
        }
    }
}