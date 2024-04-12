using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static float speed = 10f;
    private static float range = 4f;
    private Rigidbody2D rb;
    private Vector3 incialPosition;
    [SerializeField] private float inialBulletSpeed;
    [SerializeField] private float inialBulletRange;
    private void Awake()
    {
        incialPosition = GetComponent<Transform>().position;
    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, incialPosition) >= range) 
        {
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
    public float GetRange()
    {
        return range;
    }
    public void SetRange(float newRange)
    {
        range = newRange;
    }
}
