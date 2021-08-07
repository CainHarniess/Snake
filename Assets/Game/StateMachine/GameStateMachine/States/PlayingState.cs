using UnityEngine;

namespace Assets.Game
{
    public class PlayingState : State
    {
        public override void Start()
        {
            Time.timeScale = 1f;
        }

        public override void End()
        {

        }
    }
}