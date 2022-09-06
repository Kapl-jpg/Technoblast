using TMPro;

namespace Directors.UI
{
    public class UpdateTimerUI
    {
        private TextMeshProUGUI _text;
        
        public UpdateTimerUI(TextMeshProUGUI text)
        {
            _text = text;
        }

        public void UpdateUI(float timeValue)
        {
            SetText( $"{timeValue}" );            
        }
        
        private void SetText(string newText)
        {
            _text.text = newText;
        }
    }
}