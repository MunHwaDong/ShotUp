using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScoreBoard : MonoBehaviour
{
    [SerializeField]
    private ScoreViewModel scoreViewModel;

    private TextMeshProUGUI maxScoreText;

    private void Awake()
    {
        maxScoreText = GetComponent<TextMeshProUGUI>();

        scoreViewModel.onChangeMaxScore += ChangeMaxScore;
    }

    private void ChangeMaxScore(int maxScore)
    {
        maxScoreText.text = maxScore.ToString();
    }
}
