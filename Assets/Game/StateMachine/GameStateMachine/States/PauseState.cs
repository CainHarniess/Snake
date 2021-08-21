using UnityEngine;

namespace Assets.Game
{
    public class PauseState : State
    {
        private GameObject pauseMenuUI;

        public PauseState(GameObject pauseMenuUI)
        {
            this.pauseMenuUI = pauseMenuUI;
        }

        public override void Start()
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            Debug.Log("Game paused!");
        }

        public override void End()
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
    }
}