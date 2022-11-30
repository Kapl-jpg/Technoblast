using UnityEngine;
using UnityEngine.UI;

public class InitialSettings : MonoBehaviour
{
    [SerializeField] private DataFile dataFile;

    [SerializeField] private Image[] musicArrows;
    [SerializeField] private Image[] soundArrows;

    [SerializeField] private Sprite musicArrowSprite;
    [SerializeField] private Sprite soundsArrowSprite;

    private void Awake()
    {
        ChangeMusicArrows();
        ChangeSoundArrows();
    }

    private void ChangeMusicArrows()
    {
        var numberArrows = dataFile.ReadMusicVolume();
        
        for (var i = 0; i <= numberArrows; i++)
        {
            musicArrows[i].sprite = musicArrowSprite;
        }
    }

    private void ChangeSoundArrows()
    {
        var numberArrows = dataFile.ReadSoundsVolume();
        
        for (var i = 0; i <= numberArrows; i++)
        {
            soundArrows[i].sprite = soundsArrowSprite;
        }
    }
}
