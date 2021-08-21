using UnityEngine;
using Assets.Game;

namespace Assets.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUi;
        [SerializeField] private GameStateMachine gameStateMachine;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && gameStateMachine.State is PlayingState)
            {
                gameStateMachine.SetState(new PauseState(pauseMenuUi));
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && gameStateMachine.State is PauseState)
            {
                gameStateMachine.SetState(new PlayingState());
            }
        }
    }
}