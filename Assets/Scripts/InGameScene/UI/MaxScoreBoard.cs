using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScoreBoard : MonoBehaviour
{
    [SerializeField]
    private PlayDataViewModel playDataViewModel;

    private TextMeshProUGUI maxScoreText;

    private void Awake()
    {
        maxScoreText = GetComponent<TextMeshProUGUI>();

        playDataViewModel.onChangeMaxScore += ChangeMaxScore;
    }

    private void ChangeMaxScore(int maxScore)
    {
        maxScoreText.text = maxScore.ToString();
    }
}
