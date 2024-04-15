using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private int score;
    private int highScore;

    private void Start()
    {
        SetScoreValues();
    }

    private void SetScoreValues()
    {
        highScore = SaveScore.Instance.LoadMaxScore();
        score = SaveScore.Instance.CurrentScore;

        currentScoreText.text = score + "";
        highScoreText.text = highScore + "";


    }

}
