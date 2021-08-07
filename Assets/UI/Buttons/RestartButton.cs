using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Game;

namespace Assets.UI
{
    public class RestartButton : MonoBehaviour, IButton
    {
        [SerializeField] StateMachine gameStateMachine;
        public void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameStateMachine.SetState(new PlayingState());
        }
    }
}