using UnityEngine;
using TMPro;

namespace Assets.UI
{
    public class ScoreUIManager : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private const string scoreStringTemplate = "Score: {0}";

        public string ScoreString { get => textMeshProUGUI.text; }

        private void Awake()
        {
            scoreManager = GameObject.FindGameObjectWithTag(Tags.ScoreManager).GetComponent<ScoreManager>();
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateDisplay()
        {
            textMeshProUGUI.text = string.Format(scoreStringTemplate, scoreManager.Score);
        }
    }
}