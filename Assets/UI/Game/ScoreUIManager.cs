using UnityEngine;
using TMPro;

namespace Assets.UI
{
    public class ScoreUIManager : MonoBehaviour
    {
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private const string scoreStringTemplate = "Score: {0}";

        public string ScoreString { get => textMeshProUGUI.text; }

        private void Awake()
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateDisplay(string newValue)
        {
            textMeshProUGUI.text = string.Format(scoreStringTemplate, newValue);
        }
    }
}