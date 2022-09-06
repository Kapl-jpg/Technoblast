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

        public void UpdateUI(int timeValue)
        {
            var outPutString = $"{timeValue}";
            
            if (timeValue > 60)
            {
                outPutString = $"{timeValue/60}:{timeValue%60}";
            }

            SetText( outPutString );            
        }
        
        private void SetText(string newText)
        {
            _text.text = newText;
        }
    }
}