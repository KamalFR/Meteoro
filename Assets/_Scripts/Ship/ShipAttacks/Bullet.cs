using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static float speed = 10f;
    //private static float range = 4f;
    private Rigidbody2D rb;
    private float time;
    /*[SerializeField] private float inialBulletSpeed;
    [SerializeField] private float inialBulletRange;*/
    private void Awake()
    {
        time = 0f;
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 0.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Inimigo")
        {
            collision.GetComponent<Meteor>().ReciveDamage(1);
            Destroy(gameObject);
        }
    }
    public void SetMovimento()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    /*public float GetRange()
    {
        return range;
    }
    public void SetRange(float newRange)
    {
        range = newRange;
    }*/
}
