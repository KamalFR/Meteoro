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
    private int baseScoreToLevelUp;
    public int ScoreAddiction => _scoreAddiction;
    private int baseScoreAddiction;
    public float ScoreAddictionMultiplicativeFactor => _scoreAddictionMultiplicativeFactor;

    public static bool gameScene = true;


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
        baseScoreToLevelUp = _scoreToLevelUp;
        baseScoreAddiction = _scoreAddiction;
        //Preview(10);
    }

    private void Start()
    {
        _currentScore = 0;
        _scoreToLevelUp = baseScoreToLevelUp;
        _scoreAddiction = baseScoreAddiction;
        ScorePoints(0);
    }

    public void ScorePoints(int val)
    {
        if (!gameScene)
        {
            _currentScore = 0;
            _scoreToLevelUp = baseScoreToLevelUp;
            _scoreAddiction = baseScoreAddiction;
            gameScene = true;
        }
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
