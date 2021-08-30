using System;
using UnityEngine;

namespace Assets.Game
{
    public class GameStateMachine : StateMachine
    {
        public static GameStateMachine instance;

        private void Awake()
        {
            if (instance == null) instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            Sound playSound = Array.Find(audioManager.Sounds, sound => sound.Name == nameof(PlayingState));

            state = new PlayingState(playSound);
            SetState(state);
        }
    }
}