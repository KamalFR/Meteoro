using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = ScoreManager.Instance.ScoreToLevelUp;
        ChangeUIPoints(0);
    }
    private void OnEnable()
    {
        ScoreManager.OnScorePoints += ChangeUIPoints;
        ScoreManager.OnLevelUp += ResetSlider;
        ScoreManager.OnResetScore += Reset;
    }

    private void OnDisable()
    {
        ScoreManager.OnScorePoints -= ChangeUIPoints;
        ScoreManager.OnLevelUp -= ResetSlider;
        ScoreManager.OnResetScore -= Reset;
    }

    private void Reset()
    {
        _slider.value = 0.0001f;
        _slider.maxValue = ScoreManager.Instance.ScoreAddiction; ;
    }
    private void ChangeUIPoints(int val)
    {
        _textComponent.text = "" + ScoreManager.Instance.CurrentScore;
        _slider.value += val;
    }

    private void ResetSlider()
    {
        _slider.value = 0.0001f;
        _slider.maxValue = ScoreManager.Instance.ScoreAddiction;

    }

}
