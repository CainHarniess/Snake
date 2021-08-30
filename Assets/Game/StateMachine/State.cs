using UnityEngine;

namespace Assets.Game
{
    [System.Serializable]
    public abstract class State
    {
        protected AudioSource audioSource;
        protected StateMachine stateMachine;

        public StateMachine StateMachine { get => stateMachine; set => stateMachine = value; }

        public abstract void Start();

        public abstract void End();
    }
}