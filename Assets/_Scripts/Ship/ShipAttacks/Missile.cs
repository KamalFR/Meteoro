using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private GameObject explosion; 
    private GameObject createdExplosion;
    public static int explosionDamage; //o valor é definido na classe MissileControl
    private Rigidbody2D rb;
    private float time;
    private void Awake()
    {
        time = 0f;
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            createdExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            createdExplosion.GetComponent<Explosion>().SetDamage(explosionDamage);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Inimigo")
        {
            createdExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            createdExplosion.GetComponent<Explosion>().SetDamage(explosionDamage);
            Destroy(gameObject);
        }
    }
    public void SetMovimento()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

    }
}
