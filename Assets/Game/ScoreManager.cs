using UnityEngine;
using Assets.Edibles;
using Assets.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    public int Score { get => score; }

    public void IncreaseScore(BasicEdible edible)
    {
        score += edible.ScoreValue;
    }
}
