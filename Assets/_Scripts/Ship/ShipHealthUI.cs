using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;

    public static Action<int> OnChangeHealth;

    private void OnEnable()
    {
        OnChangeHealth += UpdateLives;
    }

    private void OnDisable()
    {
        OnChangeHealth -= UpdateLives;
    }

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        var lives = FindObjectOfType<ShipHealth>().Health;
        _textComponent.text = "x " + lives;
    }
    public void UpdateLives(int lives)
    {
        _textComponent.text = "x " + lives;
    }

}
