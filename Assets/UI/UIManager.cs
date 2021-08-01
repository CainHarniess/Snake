using UnityEngine;
using TMPro;

namespace Assets.UI
{
    public class UIManager : MonoBehaviour
    {
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private const string guiString = "Score: {0}";

        private void Awake()
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateDisplay(string newValue)
        {
            textMeshProUGUI.text = string.Format(guiString, newValue);
        }
    }
}