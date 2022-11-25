using UnityEngine;

namespace Directors
{
    public class BackgroundSoundsPlayer : MonoBehaviour
    {
        private static GameObject _musicManager;

        private static AudioSource _audioSource;

        public void CheckManager()
        {
            if (_musicManager == null)
            {
                DontDestroyOnLoad(gameObject);
                _musicManager = gameObject;
                SetAudioSource(_musicManager);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
        private void SetAudioSource(GameObject musicManager)
        {
            _audioSource = musicManager.GetComponent<AudioSource>();
        }
        
        public void SetLevelAudioClip(AudioClip levelClip)
        {
            if (!_audioSource.isPlaying || _audioSource.clip != levelClip || _audioSource.clip == null)
            {
                _audioSource.clip = levelClip;
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }
    }
}