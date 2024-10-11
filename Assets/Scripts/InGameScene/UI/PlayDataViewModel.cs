using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDataViewModel : MonoBehaviour
{
    private const int C_IncreaseScorePoint = 1;

    private PlayData playData;
    
    public delegate void OnChangeCurrentScore(int score);
    public event OnChangeCurrentScore onChangeCurrentScore;

    public delegate void OnChangeMaxScore(int maxScore);
    public event OnChangeMaxScore onChangeMaxScore;

    public delegate void OnDestoryViewModel(Data result);
    public event OnDestoryViewModel onDestoryViewModel;

    private void Awake()
    {
        playData = new PlayData(GameManager.playerData.maxScore);

        Init(ref this.playData);
    }

    void OnDestroy()
    {
        onDestoryViewModel?.Invoke(playData.GetInGameData());
    }

    private void Init(ref PlayData playData)
    {
        playData.onUpdateCurrentScore += ChangeCurrentScore;
        playData.onUpdateMaxScore += ChangeMaxScore;

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
        playData.ResetCurrentScore();
    }

    public void IncreaseCurrentScore()
    {
        playData.UpdateCurrentScore(C_IncreaseScorePoint);
    }

    public void UpdateMaxScore()
    {
        playData.UpdateMaxScore();
    }
}
