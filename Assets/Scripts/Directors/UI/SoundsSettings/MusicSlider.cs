using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Sounds_SO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private string _volumeName;
    [SerializeField] private AudioMixer _audioMixer;

    public void UpdateValueOnChange(float value)
    {
        if (Settings.Profile && Settings.Profile.AudioMixer)
        {
            var volume = Mathf.Log(value) * 20f;
            Settings.Profile.AudioMixer.SetFloat(_volumeName, volume);
        }
    }
}
