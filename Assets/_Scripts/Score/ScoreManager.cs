using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : SingletonTemplate<ScoreManager>
{

    [Header("Score Properties")]

    [SerializeField] private int _scoreToLevelUp = 200;
    [SerializeField] private int _scoreAddiction = 100;
    [SerializeField] private float _scoreAddictionMultiplicativeFactor = 2f;


    private int _currentScore = 0;
    public int CurrentScore => _currentScore;
    public int ScoreToLevelUp => _scoreToLevelUp;
    public int ScoreAddiction => _scoreAddiction;


    #region STATIC_ACTIONS

    public static Action<int> OnScorePoints;
    public static Action OnLevelUp;

    #endregion
    private void OnEnable()
    {
        OnScorePoints += ScorePoints;
        OnLevelUp += SetNewLevelUpValues;
    }
    private void OnDisable()
    {
        OnScorePoints -= ScorePoints;
        OnLevelUp -= SetNewLevelUpValues;
    }

    protected override void Awake()
    {
        base.Awake();
        //Preview(10);
    }

    public void ScorePoints(int val)
    {
        _currentScore += val;

        if (_currentScore < _scoreToLevelUp)
            return;

        OnLevelUp?.Invoke();

    }
    private void SetNewLevelUpValues()
    {
        _scoreToLevelUp += _scoreAddiction;
        _scoreAddiction = (int)(_scoreAddiction * _scoreAddictionMultiplicativeFactor);
    }

    private void Preview(int levels)
    {
        for (int i = 0; i < levels; i++)
        {
            Debug.Log("Level " + i + " : Score to level Up: " + _scoreToLevelUp + "; Score Addiction: " + _scoreAddiction);
            SetNewLevelUpValues();
        }
    }

}
