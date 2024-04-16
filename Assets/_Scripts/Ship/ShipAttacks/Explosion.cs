using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int explosionDamage;
    private float time;
    private void Update()
    {
        time += Time.deltaTime;
        if(time > 0.1f)
        {
            Destroy(GetComponent<CircleCollider2D>());
        }
        if(time > 0.2f)
        {
            Destroy(gameObject);
        }
    }
    public void SetDamage(int damage)
    {
        explosionDamage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Inimigo")
        {
            collision.GetComponent<Meteor>().ReciveDamage(explosionDamage);
        }
    }
}
