using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Directors.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LevelCounterTextUI : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            SetText();
        }

        private void SetText()
        {
            var currentLevelIndex = SceneManager.GetActiveScene().buildIndex ;
            _text.text = $"{currentLevelIndex}";
        }
    }
}