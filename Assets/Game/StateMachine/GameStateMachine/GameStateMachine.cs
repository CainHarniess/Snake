namespace Assets.Game
{
    public class GameStateMachine : StateMachine
    {
        private void Awake()
        {
            state = new PlayingState();
            SetState(new PlayingState());
        }
    }
}