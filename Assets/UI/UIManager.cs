using UnityEngine;
using Assets.Game;

namespace Assets.UI
{
    public class UIManager : MonoBehaviour
    {
        private GameStateMachine gameStateMachine;

        [SerializeField] private GameObject pauseMenuUi;
        
        private void Awake()
        {
            gameStateMachine = GameObject.FindGameObjectWithTag(Tags.GameStateMachine).GetComponent<GameStateMachine>();
        }

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

