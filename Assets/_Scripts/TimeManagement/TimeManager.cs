using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonTemplate<TimeManager>
{

    [SerializeField] private float _timeToIncreaseLevel = 40f;
    [SerializeField] private float _timeAddiction = 60f;
    [SerializeField] private float _scoreAddictionMultiplicaticeFactor = 1.3f;
    private float _timeForNextEvent;
    [SerializeField] [Range(0f, .8f)] private float _eventTime = .5f;
    private bool eventTriggered = false;

    private float _currentTime = 0f;

    public float TimeAddiction => _timeAddiction;
    public float TimeToIncreaseLevel => _timeToIncreaseLevel;
    public float CurrentTime => _currentTime;

    public static Action OnTimeScale;
    public static Action OnEventTriggered;
    protected override void Awake()
    {
        base.Awake();
        _timeForNextEvent = _timeToIncreaseLevel * _eventTime;
    }

    private void OnEnable()
    {
        OnTimeScale += ScaleLevelUp;
    }

    private void OnDisable()
    {
        OnTimeScale -= ScaleLevelUp;
    }
    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime < _timeForNextEvent)
            return;

        if(!eventTriggered)
            OnEventTriggered?.Invoke();

        eventTriggered = true;

        if (_currentTime < _timeToIncreaseLevel)
            return;

        OnTimeScale?.Invoke();
    }

    public void ScaleLevelUp()
    {
        _currentTime = 0f;
        eventTriggered = false;
        _timeToIncreaseLevel += _timeAddiction;
        _timeAddiction *= _scoreAddictionMultiplicaticeFactor;
        _timeForNextEvent = _timeToIncreaseLevel * _eventTime;
        Debug.Log(_timeToIncreaseLevel +"/n " + _timeAddiction + "/n" + _timeForNextEvent);
    }

}
