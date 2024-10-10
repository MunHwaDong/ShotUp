using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private PlayDataViewModel playDataViewModel;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        playDataViewModel.onChangeCurrentScore += ChangeScore;
    }

    private void ChangeScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
