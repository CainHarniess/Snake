using UnityEngine;

namespace Assets.Game
{
    public class GameOverState : State
    {
        private GameObject gameOverUI;

        public GameOverState(GameObject gameOverUI)
        {
            this.gameOverUI = gameOverUI;
        }

        public GameOverState(Sound gameOverSound, GameObject gameOverUI)
        {
            audioSource = gameOverSound.AudioSource;
            this.gameOverUI = gameOverUI;
        }

        public override void Start()
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
            audioSource?.Play();
        }

        public override void End()
        {
            gameOverUI.SetActive(false);
            Time.timeScale = 1f;
            audioSource?.Stop();
        }
    }
}