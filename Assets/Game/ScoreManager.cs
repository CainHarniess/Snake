using UnityEngine;
using Assets.Edibles;
using Assets.UI;

[RequireComponent(typeof(ScoreUIManager))]
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private ScoreUIManager scoreUIManager;
    public int Score { get => score; }

    private void Awake()
    {
        scoreUIManager = GetComponent<ScoreUIManager>();
    }

    public void IncreaseScore(BasicEdible edible)
    {
        score += edible.ScoreValue;
        scoreUIManager.UpdateDisplay(score.ToString());
    }
}
