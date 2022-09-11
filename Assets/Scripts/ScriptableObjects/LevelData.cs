using Data;
using UnityEngine;

namespace ScriptableObjects
{       
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 3)]
    public class LevelData : ScriptableObject
    {
        [Header("Global Spray Can Count")]
        [SerializeField] private int _sprayCanInAllLevels; 
        public int SprayCanInAllLevels => _sprayCanInAllLevels;
        
        [Header("Level State Data"), Space(10)]
        [SerializeField] private LevelStateData _levelStateData;
        public LevelStateData GetLevelStateData => _levelStateData;
        
        public void SetLevelStateData(LevelStateData data) => _levelStateData = data;
    }
}