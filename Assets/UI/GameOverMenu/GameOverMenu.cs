using UnityEngine;
using TMPro;
using Assets.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] private const string scoreStringTemplate = "Score: {0}";

    void Start()
    {
        textMeshProUGUI.text = string.Format(scoreStringTemplate, scoreManager.Score);
    }
}
