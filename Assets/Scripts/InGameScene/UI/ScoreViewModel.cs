using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreViewModel : MonoBehaviour
{
    private const int C_IncreaseScorePoint = 1;
    private GameManager gameManager;

    private PlayerData playerData;
    
    public delegate void OnChangeCurrentScore(int score);
    public event OnChangeCurrentScore onChangeCurrentScore;

    public delegate void OnChangeMaxScore(int maxScore);
    public event OnChangeMaxScore onChangeMaxScore;

    public delegate void OnDestoryViewModel(Data data);
    public event OnDestoryViewModel onDestoryViewModel;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerData = new PlayerData(gameManager.maxScore);

        Init(ref this.playerData);
    }

    void OnDestroy()
    {
        onDestoryViewModel?.Invoke(playerData.GetInGameData());
    }

    private void Init(ref PlayerData playerData)
    {
        playerData.onUpdateCurrentScore += ChangeCurrentScore;
        playerData.onUpdateMaxScore += ChangeMaxScore;

        EventBus.Subscribe(EventType.IDLE, IncreaseCurrentScore);
        EventBus.Subscribe(EventType.CRUSH, UpdateMaxScore);
        EventBus.Subscribe(EventType.RESTART, ResetCurrentScore);
    }

    private void ChangeCurrentScore(int score)
    {
        onChangeCurrentScore?.Invoke(score);
    }

    private void ChangeMaxScore(int maxScore)
    {
        onChangeMaxScore?.Invoke(maxScore);
    }

    private void ResetCurrentScore()
    {
        playerData.ResetCurrentScore();
    }

    public void IncreaseCurrentScore()
    {
        playerData.UpdateCurrentScore(C_IncreaseScorePoint);
    }

    public void UpdateMaxScore()
    {
        playerData.UpdateMaxScore();
    }
}
