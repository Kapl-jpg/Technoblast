using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private DataFile dataFile;
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private float minMusicVolume;
    [SerializeField] private float maxMusicVolume;
    [SerializeField] private float minSoundVolume;
    [SerializeField] private float maxSoundVolume;

    [SerializeField] private int arrowsCount;

    private void Start()
    {
        SetStartValue();
    }

    private void SetStartValue()
    {
        var stepMusic = (maxMusicVolume - minMusicVolume) / arrowsCount;
        masterMixer.SetFloat("Music", minMusicVolume + stepMusic * dataFile.ReadMusicVolume());

        var stepSound = (maxSoundVolume - minSoundVolume) / arrowsCount;
        masterMixer.SetFloat("Effects",minMusicVolume + stepSound * dataFile.ReadSoundsVolume());
    }

    public void SetMusicValue(int numberStep)
    {
        var stepMusic = (maxMusicVolume - minMusicVolume) / arrowsCount;
        masterMixer.SetFloat("Music", minMusicVolume + numberStep * stepMusic);
    }

    public void SetSoundValue(int numberStep)
    {
        var stepSound = (maxSoundVolume - minSoundVolume) / arrowsCount;
        masterMixer.SetFloat("Effects", minSoundVolume + numberStep * stepSound);
    }
}
