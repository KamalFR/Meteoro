using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] private int inicialHealth;
    private int health;
    public int Health => health;
    private void Awake()
    {
        health = inicialHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("HighScoreScene");
            SaveScore.OnSaveScore?.Invoke(ScoreManager.Instance.CurrentScore);
            Destroy(gameObject);
        }
    }
    public void ReciveDamage()
    {
        health--;
        ShipHealthUI.OnChangeHealth?.Invoke(health);
    }
}
