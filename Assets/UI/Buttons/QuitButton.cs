using UnityEngine;

namespace Assets.UI
{
    public class QuitButton : Button
    {
        public override void OnButtonClick()
        {
            Application.Quit();
        }
    }
}