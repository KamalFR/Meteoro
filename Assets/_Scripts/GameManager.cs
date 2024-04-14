using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonTemplate<GameManager>
{
    [Header("ASTEROIDS RELATED")]

    [SerializeField] private int healthIncrease;
    [SerializeField] private float velocityIncrease;
    private int _currentLevel = 0;
    private GameObject _playerReference;
    private GameObject _powerSelectionUI;

    public int CurrentLevel => _currentLevel;
    public int HealthIncrease => healthIncrease;
    public float VelocityIncrease => velocityIncrease;

    #region SETUP
    protected override void Awake()
    {
        base.Awake();
        _powerSelectionUI = GameObject.Find("PowerSelectionUI");
    }

    private void Start()
    {
        _currentLevel = 0;
        //_playerReference = FindObjectOfType<ShipMovement>().gameObject;
    }

    private void OnEnable()
    {
        TimeManager.OnTimeScale += ChangeAsteroidsLevel;

        ScoreManager.OnLevelUp += LevelUpShip;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeScale -= ChangeAsteroidsLevel;

        ScoreManager.OnLevelUp -= LevelUpShip;
    }

    #endregion

    private void ChangeAsteroidsLevel()
    {
        _currentLevel++;
        healthIncrease = healthIncrease * CurrentLevel;
    }

    private void LevelUpShip()
    {
        _powerSelectionUI.transform.GetChild(0).gameObject.SetActive(true);
        PauseGame();
    }

    public void AddTripleShot()
    {
        //var currentClass = _playerReference.GetComponent<ShipMovement>();
        //if(!currentClass.enabled)
        //enable
        //else
        //currentClass.AddPower(++) // controlado pela classe
        ResumeGame();

    }

    public void AddRocketShot()
    {
        ResumeGame();

    }
    public void AddLaserShot()
    {
        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _powerSelectionUI.transform.GetChild(0).gameObject.SetActive(false);
    }


}
