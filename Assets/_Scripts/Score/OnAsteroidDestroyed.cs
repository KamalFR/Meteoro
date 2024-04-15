using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAsteroidDestroyed : MonoBehaviour
{
    [SerializeField] private int _pointsValue;
    private void OnDisable()
    {
                                       
        ScoreManager.OnScorePoints.Invoke((int)(_pointsValue * ScoreManager.Instance.ScoreAddictionMultiplicativeFactor));
    }
}
