using System.Text;
using TMPro;

namespace Directors.UI
{
    public class UpdateTimerUI
    {
        private TextMeshProUGUI _text;

        private StringBuilder _stringBuilder;

        public UpdateTimerUI()
        {
            _stringBuilder = new StringBuilder();
        }
        
        public UpdateTimerUI(TextMeshProUGUI text)
        {
            _text = text;
            _stringBuilder = new StringBuilder();
        }

        public void UpdateUI(int timeValue)
        {
            _text.text = GetStringInTimeFormat(timeValue);
        }

        public string GetStringInTimeFormat(int totalTimeInSeconds)
        {
            _stringBuilder.Clear();
            
            var minutes = totalTimeInSeconds / 60;
            var seconds = totalTimeInSeconds % 60;

            _stringBuilder.Append(minutes > 9 ? $"{minutes}" : $"0{minutes}");
            _stringBuilder.Append(":");
            _stringBuilder.Append(seconds > 9 ? $"{seconds}" : $"0{seconds}");

            return _stringBuilder.ToString();
        }

        public string GetStringInTimeFormatWithHours(int totalTimeInSeconds)
        {
            _stringBuilder.Clear();
            
            var hours = totalTimeInSeconds / 3600;
            var minutes = (totalTimeInSeconds % 3600) / 60;
            var seconds = totalTimeInSeconds % 60;

            _stringBuilder.Append(minutes > 9 ? $"{hours}" : $"0{hours}");
            _stringBuilder.Append(":");
            _stringBuilder.Append(minutes > 9 ? $"{minutes}" : $"0{minutes}");
            _stringBuilder.Append(":");
            _stringBuilder.Append(seconds > 9 ? $"{seconds}" : $"0{seconds}");

            return _stringBuilder.ToString();
        }
}
}