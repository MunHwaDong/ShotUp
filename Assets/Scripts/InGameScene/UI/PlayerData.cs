using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private int currentScore;
    public int maxScore { get; private set; }

    public delegate void OnUpdateCurrentScore(int score);
    public event OnUpdateCurrentScore onUpdateCurrentScore;

    public delegate void OnUpdateMaxScore(int score);
    public event OnUpdateMaxScore onUpdateMaxScore;

    public PlayerData()
    {
        currentScore = 0;
        maxScore = 0;
    }

    public PlayerData(int maxScore)
    {
        currentScore = 0;
        this.maxScore = maxScore;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
        onUpdateCurrentScore?.Invoke(currentScore);
    }

    public void UpdateCurrentScore(int score)
    {
        currentScore += score;
        onUpdateCurrentScore?.Invoke(currentScore);
    }

    public void UpdateMaxScore()
    {
        maxScore = Mathf.Max(maxScore, currentScore);
        onUpdateMaxScore?.Invoke(maxScore);
    }
}
