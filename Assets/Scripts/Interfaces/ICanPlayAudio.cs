using System;
using UnityEngine;

namespace Interfaces
{
    public interface ICanPlayAudio
    {
        public AudioClip CurrentClip { get; set; }
        public void PlayOneShot(AudioClip audio);
        public void Play(AudioClip audio);
    }
}