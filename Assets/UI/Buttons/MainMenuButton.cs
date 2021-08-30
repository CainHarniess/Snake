using System;
using UnityEngine.SceneManagement;
using Assets.Game;

namespace Assets.UI
{
    public class MainMenuButton : Button
    {
        public override void OnButtonClick()
        {
            gameStateMachine.SetState(
                new PlayingState(
                    Array.Find(
                        gameStateMachine.AudioManager.Sounds, sound => sound.Name == nameof(PlayingState)
                        )
                    )
                );
            SceneManager.LoadScene(0);
        }
    }
}
