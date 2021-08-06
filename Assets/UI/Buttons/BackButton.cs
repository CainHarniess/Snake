using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI
{
    public class BackButton : MonoBehaviour, IButton
    {
        public void OnButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}