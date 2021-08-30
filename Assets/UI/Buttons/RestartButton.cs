using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Game;

namespace Assets.UI
{
    public class RestartButton : Button
    {
        public override void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameStateMachine.SetState(
                new PlayingState(
                    Array.Find(
                        gameStateMachine.AudioManager.Sounds, sound => sound.Name == nameof(PlayingState)
                        )
                    )
                );
        }
    }
}