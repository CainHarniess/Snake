using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI
{
    public class PlayButton : MonoBehaviour,  IButton
    {
        public void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}