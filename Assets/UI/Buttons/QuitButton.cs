using UnityEngine;

namespace Assets.UI
{
    public class QuitButton : MonoBehaviour, IButton
    {
        public void OnButtonClick()
        {
            Application.Quit();
        }
    }
}