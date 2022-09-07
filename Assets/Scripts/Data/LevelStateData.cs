using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public struct LevelStateData
    {
        [SerializeField] private int _sprayCanCounter;
        public int SprayCanCounter => _sprayCanCounter;

        [SerializeField] private float _globalGameTimer;
        public float GlobalGameTimer => _globalGameTimer;

        public LevelStateData(int sprayCanCounter, float globalGameTimer)
        {
            _sprayCanCounter = sprayCanCounter;
            _globalGameTimer = globalGameTimer;
        }

        public void RefreshData(int sprayCanCounter, float globalGameTimer)
        {
            _sprayCanCounter = sprayCanCounter;
            _globalGameTimer = globalGameTimer;
        }

        public void SetGlobalGameTimer(float value)
        {
            _globalGameTimer = value;
        }
    }
}