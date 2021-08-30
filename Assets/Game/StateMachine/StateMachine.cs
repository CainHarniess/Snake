using UnityEngine;

namespace Assets.Game
{
    public abstract class StateMachine : MonoBehaviour
    {
        [SerializeField] protected State state;
        [SerializeField] protected string stateName;
        [SerializeField] protected AudioManager audioManager;
        public AudioManager AudioManager { get => audioManager; }

        public State State { get => state; }

        public virtual void SetState(State state)
        {
            if (state != null ) this.state.End();

            this.state = state;
            this.state.StateMachine = this;
            stateName = state.GetType().Name;
            this.state.Start();
        }
    }
}