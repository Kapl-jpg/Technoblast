using Interfaces;

namespace Directors
{
    public class TrickMoveSounds : ILastBreath
    {
        private TrickMove _trickMove;
        private ICanPlayAudio _audioPlayer;
        private SoundsContainer _sounds;
        
        public TrickMoveSounds(TrickMove trickMove, ICanPlayAudio audioPlayer, SoundsContainer sounds)
        {
            _trickMove = trickMove;
            _audioPlayer = audioPlayer;
            _sounds = sounds;

            _trickMove.OnTrickMissEvent += PlayRandomAudioClip;
        }
        
        public void LastBreath()
        {
            _trickMove.OnTrickMissEvent -= PlayRandomAudioClip;
        }

        private void PlayRandomAudioClip()
        {
            if (_sounds.IsAvailableClips())
            {
               var audio = _sounds.GetRandomAudioClip();
               _audioPlayer.PlayOneShot(audio);
            }
        }
    }
}