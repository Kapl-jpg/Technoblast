using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    
    private Slider _musicSlider;
    
    private void Start()
    {
        _musicSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
