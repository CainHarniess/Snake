using System;
using UnityEngine;

namespace Assets.Game
{
    [System.Serializable]
    public class PlayingState : State
    {
        
        public PlayingState() { }
        public PlayingState(Sound playSound)
        {
            audioSource = playSound.AudioSource;
        }
        public override void Start()
        {
            Time.timeScale = 1f;
            audioSource?.Play();
        }

        public override void End()
        {
            audioSource?.Stop();
        }
    }
}