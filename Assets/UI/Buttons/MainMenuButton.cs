using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI
{
    public class MainMenuButton : MonoBehaviour, IButton
    {
        public void OnButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}