using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.PlasticSCM.Editor.WebApi;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;

    private void OnEnable()
    {
        ScoreManager.OnScorePoints += ChangeUIPoints;
    }

    private void OnDisable()
    {
        ScoreManager.OnScorePoints -= ChangeUIPoints;
    }
    private void ChangeUIPoints(int val)
    {
        _textComponent.text = "" + ScoreManager.Instance.CurrentScore;
    }

}
