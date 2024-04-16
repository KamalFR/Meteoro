using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAsteroidDestroyed : MonoBehaviour
{
    [SerializeField] private int _pointsValue;
    private ParticleSystem _particles;

    private void Awake()
    {
        _particles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnDisable()
    {
        var child = GetComponentInChildren<AudioSource>();
        child.transform.parent = null;
        child.enabled = true;
        child.Play();
    }
    private void OnDestroy()
    {
        if(ScoreManager.Instance != null)                               
            ScoreManager.OnScorePoints.Invoke((int)(_pointsValue * ScoreManager.Instance.ScoreAddictionMultiplicativeFactor));

        _particles.transform.parent = null;

        _particles.Play();

    }
}
