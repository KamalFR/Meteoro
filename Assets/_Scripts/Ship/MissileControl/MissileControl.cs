using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    private int level;
    private MissileAttack missile;
    private float timeForCooldown;
    public MissileControl()
    {
        level = 1;
        missile = new MissileAttack();
        timeForCooldown = 10f;
        Missile.explosionDamage = 20;
    }
    public void UpgradeMissile() //resolvi intercalar entre dano e cooldown
    {
        level++;
        if (level <= 5)
        {
            timeForCooldown -= 1;
        }
        if ((level > 5)&&(level <= 8))
        {
            Missile.explosionDamage += 5; 
        }
        if((level > 8)&&(level <= 13))
        {
            timeForCooldown -= 1;
        } //nao vai zerar
        if(level > 13)
        {
            Missile.explosionDamage += 5;
        }
    }
    public float GetTimeForCooldown()
    {
        return timeForCooldown;
    }
    public void Attack(Vector3 position, GameObject rocket, Transform shipTransform)
    {
        missile.Attack(position, rocket, shipTransform);
    }
}
