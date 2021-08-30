using UnityEngine;
using TMPro;
using Assets;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] private const string scoreStringTemplate = "Score: {0}";

    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag(Tags.ScoreManager).GetComponent<ScoreManager>();
    }

    void Start()
    {
        textMeshProUGUI.text = string.Format(scoreStringTemplate, scoreManager.Score);
    }
}
