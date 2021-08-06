using UnityEngine;

namespace Assets.UI
{
    public class OptionsButton : MonoBehaviour, IButton
    {
        [SerializeField] GameObject optionsMenuGameObject;
        public void OnButtonClick()
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            optionsMenuGameObject.SetActive(true);
        }
    }
}