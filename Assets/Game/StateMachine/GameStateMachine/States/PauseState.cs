using UnityEngine;

namespace Assets.Game
{
    public class PauseState : State
    {
        public override void Start()
        {
            Time.timeScale = 0f;
            Debug.Log("Game paused!");
        }

        public override void End()
        {
            Time.timeScale = 1f;
        }
    }
}