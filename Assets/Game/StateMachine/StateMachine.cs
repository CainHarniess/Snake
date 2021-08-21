using UnityEngine;

namespace Assets.Game
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State state;
        [SerializeField] protected string stateName;

        public State State { get => state; }

        public virtual void SetState(State state)
        {
            if (state != null ) this.state.End();
            this.state = state;
            stateName = state.GetType().Name;
            this.state.Start();
        }
    }
}