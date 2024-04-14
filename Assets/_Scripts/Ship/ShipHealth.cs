using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] private int inicialHealth;
    private int health;
    private void Start()
    {
        health = inicialHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ReciveDamage()
    {
        health--;
    }
}
