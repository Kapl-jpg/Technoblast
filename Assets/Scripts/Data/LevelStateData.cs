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

        [SerializeField] private int _globalDeathCounter;

        public int GlobalDeathCounter
        {
            get => _globalDeathCounter;
            set => _globalDeathCounter = value > 0 ? value : 0;
        }

        public LevelStateData(int sprayCanCounter, float globalGameTimer, int globalDeathCounter)
        {
            _sprayCanCounter = sprayCanCounter;
            _globalGameTimer = globalGameTimer;
            _globalDeathCounter = globalDeathCounter;
        }

        public void RefreshData(int sprayCanCounter, float globalGameTimer, int globalDeathCounter)
        {
            _sprayCanCounter = sprayCanCounter;
            _globalGameTimer = globalGameTimer;
            _globalDeathCounter = globalDeathCounter;
        }

        public void SetGlobalGameTimer(float value)
        {
            _globalGameTimer = value;
        }
    }
}