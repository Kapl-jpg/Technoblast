using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Directors.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LevelCounterTextUI : MonoBehaviour
    {
        [SerializeField] private int levelNumber;
        private TextMeshProUGUI _text;

        
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            SetText();
        }

        
        private void SetText()
        {
            _text.text = $"{levelNumber}";
        }
    }
}