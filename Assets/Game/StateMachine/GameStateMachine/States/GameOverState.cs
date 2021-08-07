using UnityEngine;

namespace Assets.Game
{
    public class GameOverState : State
    {
        private GameObject gameOverUI;
        

        public override void Start()
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }

        public override void End()
        {
            gameOverUI.SetActive(false);
            Time.timeScale = 1f;
        }

        public GameOverState(GameObject gameOverUI)
        {
            this.gameOverUI = gameOverUI;
        }
    }
}