using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Directors.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GlobalSprayCanCounter : MonoBehaviour
    {
        [SerializeField] private InventoryComponent _inventory;

        private DataFile _dataFile;
        private int _currentSprayCanCounter;
        public int CurrentSprayCanCounter
        {
            get => _currentSprayCanCounter;
            set
            { 
                _currentSprayCanCounter = value > 0 ? value : 0;
            }
        }
        
        private TextMeshProUGUI _sprayCanCounterText;

        [Inject]
        private void Construct(DataFile dataFile)
        {
            _dataFile = dataFile;
        }
        
        private void Start()
        {
            _sprayCanCounterText = GetComponent<TextMeshProUGUI>();
            _currentSprayCanCounter = _dataFile.ReadSprayCount();
            _inventory.OnItemAddedEvent += IncreaseCounter;
            SetText($"{_currentSprayCanCounter}");
        }
        
        private void IncreaseCounter()
        {
            _currentSprayCanCounter++;
            SetText($"{_currentSprayCanCounter}");
            _dataFile.WriteSprayCount(_currentSprayCanCounter);
        }

        private void SetText(string text)
        {
            _sprayCanCounterText.text = text;
        }
    }
}