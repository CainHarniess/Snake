using UnityEngine;
using Assets.Edibles;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    public int Score { get => score; }

    public void IncreaseScore(Edible edible)
    {
        this.score += edible.ScoreValue;
    }
}
