using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions.Must;
using static UnityEngine.ParticleSystem;

public class Meteor : MonoBehaviour
{
    [SerializeField] private int meteorHealth;
    [SerializeField] private int multiplicate;
    [SerializeField] private GameObject newMeteor;
    [SerializeField] private float speed;

    [SerializeField] private int _pointsValue;
    [SerializeField] private ParticleSystem _particles;

    private int health;
    private Vector3 aux;
    private Rigidbody2D rb;
    private void Awake()
    {
        health = meteorHealth;
        Randomize();
        aux.z = 0f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = aux * speed;

    }

    private void Start()
    {
        var angle = (Vector3.Angle(transform.right, rb.velocity));

        if (rb.velocity.y <= 0f)
        {
            if (angle >= 0)
                transform.Rotate(0f, 0f, -angle + 180f);
            if (angle < 0)
                transform.Rotate(0f, 0f, angle + 90f);
        } 
        else
        {
            if (angle >= 0)
                transform.Rotate(0f, 0f, angle + 180f);
            if (angle < 0)
                transform.Rotate(0f, 0f, -angle + 90f);
        }

    }
    private void Update()
    {
        if(health <= 0)
        {
            if (multiplicate>0)
            {
                GameObject meteor1;
                GameObject meteor2;
                meteor1 = Instantiate(newMeteor, rb.position, Quaternion.identity);
                meteor1.GetComponent<Meteor>().DecreaseMultiplicate();
                meteor1.GetComponent<Meteor>().SetMeteorHealth(meteorHealth - 1);
                meteor2 = Instantiate(newMeteor, rb.position, Quaternion.identity);
                meteor2.GetComponent<Meteor>().DecreaseMultiplicate();
                meteor2.GetComponent<Meteor>().SetMeteorHealth(meteorHealth - 1);
            }

            if (ScoreManager.Instance != null)
                ScoreManager.OnScorePoints.Invoke((int)(_pointsValue * ScoreManager.Instance.ScoreAddictionMultiplicativeFactor));


            Instantiate(_particles, transform.position, Quaternion.identity);

            var child = GetComponentInChildren<AudioSource>();
            child.transform.parent = null;
            child.enabled = true;
            child.Play();

            Destroy(gameObject);
        }
    }
    public void Randomize()
    {
        System.Random aleatorio = new System.Random();
        int a = (aleatorio.Next() % 3) - 1;
        int b = (aleatorio.Next() % 3) - 1;
        SetAuxForVelocity(a, b);
    }
    private void SetAuxForVelocity(int a, int b)
    {
        if (Math.Abs(a)== Math.Abs(b)){
            if (a == 0)
            {
                Randomize();
            }
            else
            {
                aux.x = a * 0.7f;
                aux.y = b * 0.7f;
            }
        }
        else
        {
            aux.x = a;
            aux.y = b;
        }
    }
    public void DecreaseMultiplicate()
    {
        multiplicate--;
    }
    public void ReciveDamage(int damage)
    {
        health -= damage;
    }
    private void SetMeteorHealth(int newMeteorHealth)
    {
        health = newMeteorHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Jogador")
        {
            collision.GetComponent<ShipHealth>().ReciveDamage();
        }
    }
}
