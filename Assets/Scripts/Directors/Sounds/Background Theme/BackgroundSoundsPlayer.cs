using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : MonoBehaviour
    {
        public static GameObject MusicManager;

        public static AudioSource AudioSource;

        public void CheckManager()
        {
            if (MusicManager == null)
            {
                DontDestroyOnLoad(gameObject);
                MusicManager = gameObject;
                SetAudioSource(MusicManager);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void SetAudioSource(GameObject musicManager)
        {
            AudioSource = musicManager.GetComponent<AudioSource>();
        }
        
        public void SetLevelAudioClip(AudioClip levelClip)
        {
            if (!AudioSource.isPlaying || AudioSource.clip != levelClip || AudioSource.clip == null)
            {
                AudioSource.clip = levelClip;
                AudioSource.loop = true;
                AudioSource.Play();
            }
        }
    }
}