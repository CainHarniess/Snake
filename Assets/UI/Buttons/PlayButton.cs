using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Game;

namespace Assets.UI
{
    public class PlayButton : Button
    {

        public override void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}