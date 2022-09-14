using System;
using ScriptableObjects.Sounds_SO;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private string _volumeName;

    public Slider _slider { get; set; }
    
    
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
        ResetSliderValue();
        UpdateValueOnChange(_slider.value);
        _slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(_slider.value);
        });
    }

    public void UpdateValueOnChange(float value)
    {
        if (Settings.Profile)
        {
             Settings.Profile.SetAudioLevels(_volumeName,value);
        }
    }

    public void ResetSliderValue()
    {
        if (Settings.Profile)
        {
            var volume = Settings.Profile.GetAudioLevels(_volumeName);
            
            UpdateValueOnChange(volume);
            GetComponent<Slider>().value = volume;
        }
    }
}
