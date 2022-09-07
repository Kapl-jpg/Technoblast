using Data;
using UnityEngine;

namespace ScriptableObjects
{       
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 3)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private LevelStateData _levelStateData;
        
        public LevelStateData GetLevelStateData => _levelStateData;
        
        public void SetLevelStateData(LevelStateData data) => _levelStateData = data;
    }
}