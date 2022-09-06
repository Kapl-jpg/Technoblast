using TMPro;
using UnityEngine;

namespace Directors.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GlobalSprayCanCounter : SingleInstanceObject
    {
        [SerializeField] private InventoryComponent _inventory;

        private TextMeshProUGUI _sprayCanCounterText;
        private int _currentSprayCanCounter;
        
        protected override void Init()
        {
            _sprayCanCounterText = GetComponent<TextMeshProUGUI>();
            SetText("0");
            _inventory.OnItemAddedEvent += UpdateUI;
        }

        private void UpdateUI()
        {
            _currentSprayCanCounter++;
            SetText( $"{_currentSprayCanCounter}" );
        }

        private void SetText(string text)
        {
            _sprayCanCounterText.text = text;
        }
    }
}