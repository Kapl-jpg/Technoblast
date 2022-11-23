using Directors;
using UnityEngine;

public class InstantiateBackgroundSound : MonoBehaviour
{
    [SerializeField] private AudioClip levelAudioClip;
    [SerializeField] private GameObject audioManager;

    private GameObject _manager;
    private void Awake()
    {
        SetAudioManager();
    }

    private void SetAudioManager()
    {
        var instance = Instantiate(audioManager);
        var backgroundMusic = instance.GetComponent<BackgroundSoundsPlayer>();
        backgroundMusic.CheckManager();
        backgroundMusic.SetLevelAudioClip(levelAudioClip);
    }
}