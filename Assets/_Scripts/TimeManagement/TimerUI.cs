using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = TimeManager.Instance.TimeToIncreaseLevel;
    }

    private void OnEnable()
    {
        TimeManager.OnTimeScale += ResetSlider;
    }

    private void OnDisable()
    {
       TimeManager.OnTimeScale -= ResetSlider;
    }

    private void Update()
    {
        ChangeUITime(TimeManager.Instance.CurrentTime);
    }

    private void ChangeUITime(float current)
    {
        string seconds = ((int)(current % 60)).ToString("00");
        string minutes = ((int)(current / 60)).ToString("00");
        _textComponent.text = minutes + ":" + seconds;
        _slider.value = current;

    }

    private void ResetSlider()
    {
        _slider.value = 0.0001f;
        _slider.maxValue = TimeManager.Instance.TimeToIncreaseLevel + TimeManager.Instance.TimeAddiction;

    }
}
