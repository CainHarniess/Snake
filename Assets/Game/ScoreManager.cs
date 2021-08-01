using UnityEngine;
using Assets.Edibles;
using Assets.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private UIManager ui;
    public int Score { get => score; }

    public void IncreaseScore(Edible edible)
    {
        score += edible.ScoreValue;
        ui.UpdateDisplay(score.ToString());
    }
}
