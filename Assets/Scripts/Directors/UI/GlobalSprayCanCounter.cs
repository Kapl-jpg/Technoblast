using System;
using TMPro;
using UnityEngine;

namespace Directors.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GlobalSprayCanCounter : MonoBehaviour
    {
        [SerializeField] private InventoryComponent _inventory;

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

        private void Start()
        {
            _sprayCanCounterText = GetComponent<TextMeshProUGUI>();
            _inventory.OnItemAddedEvent += IncreaseCounter;
            SetText($"{_currentSprayCanCounter}");
        }
        
        private void IncreaseCounter()
        {
            _currentSprayCanCounter++;
            SetText($"{_currentSprayCanCounter}");
        }

        private void SetText(string text)
        {
            _sprayCanCounterText.text = text;
        }
    }
}