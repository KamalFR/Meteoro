using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : SingletonTemplate<SaveScore>
{
    public static Action<int> OnSaveScore;

    private int currentScore = 0;
    public int CurrentScore => currentScore;
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        OnSaveScore += SaveMaxScore;
    }
    private void OnDisable()
    {
        OnSaveScore -= SaveMaxScore;
    }
    private void SaveMaxScore(int val)
    {
        var max = LoadMaxScore();
        currentScore = val;

        if(max < val)               
            PlayerPrefs.SetInt("MaxScore", val);
    }
    public int LoadMaxScore()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
            return PlayerPrefs.GetInt("MaxScore");
        else 
            return 0;
    }


}
