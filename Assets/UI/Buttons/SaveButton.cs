using UnityEngine.SceneManagement;

namespace Assets.UI
{
    public class SaveButton : Button
    {
        public override void OnButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}