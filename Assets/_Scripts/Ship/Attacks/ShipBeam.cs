using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBeam : MonoBehaviour
{
    [SerializeField] private float range = 4f;
    [SerializeField] private GameObject point;
    [SerializeField] private float cooldownTime = 2f;
    [SerializeField] private int damage = 2; 
    private bool cooldownEnd;
    private float time;
    private int level;
    private void OnEnable()
    {
        cooldownEnd = true;
        time = 0f;
        level = 1;
    }
    private void Update()
    {
        if (!cooldownEnd)
        {
            time += Time.deltaTime;
            if (time > cooldownTime)
            {
                cooldownEnd = true;
                time = 0f;
            }
        }
        else
        {
            RayHit();
        }
    }
    private void RayHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.transform.position, transform.TransformDirection(Vector2.up), range);
        if (hit)
        {
            if (hit.transform.tag == "Inimigo")
            {
                hit.transform.GetComponent<Meteor>().ReciveDamage(damage);
                cooldownEnd = false;
            }
        }
    }
    public void Upgrade()
    {
        level++;
        if(level <= 4)
        {
            cooldownTime -= 0.5f;
        }
        else
        {
            damage++;
        }
    }
}
