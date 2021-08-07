using UnityEngine;

namespace Assets.Game
{
    public abstract class State
    {
        public abstract void Start();

        public abstract void End();
    }
}