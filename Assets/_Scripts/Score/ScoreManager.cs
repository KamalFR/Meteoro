using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : SingletonTemplate<ScoreManager>
{

    private int _currentScore = 0;
    public int CurrentScore => _currentScore;

    public static Action<int> OnScorePoints;

    private void OnEnable()
    {
        OnScorePoints += ScorePoints;
    }

    private void OnDisable()
    {
        OnScorePoints -= ScorePoints;
    }

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("teste");
    }

    public void ScorePoints(int val)
    {
        _currentScore += val;
    }
}
