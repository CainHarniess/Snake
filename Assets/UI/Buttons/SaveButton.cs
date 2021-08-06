using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI
{
    public class SaveButton : MonoBehaviour, IButton
    {
        public void OnButtonClick()
        {
            Debug.Log("Settings saved.");
            SceneManager.LoadScene(0);
        }
    }
}