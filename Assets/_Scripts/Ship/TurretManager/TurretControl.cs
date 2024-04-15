using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    private int level;
    private BaseForAttacks actualTurret;
    private float timeForCooldown;
    public TurretControl()
    {
        level = 1;
        actualTurret = new BasicShot();
        timeForCooldown = 1f;
        Bullet.bulletDamage = 2; //definir o dano da bala
    }
    public void UpgradeTurret()
    {
        level++;
        if (level <= 5)
        {
            if(level == 2)
            {
                actualTurret = new DoubleShoot();
            }
            if (level == 3)
            {
                actualTurret = new TripleShoot();
            }
            if (level == 4)
            {
                actualTurret = new QuadrupleShoot();
            }
            if (level == 5)
            {
                actualTurret = new QuintupleShoot();
            }
        }
        if((level < 10)&&(level > 5)) 
        {
            timeForCooldown -= 0.1f;
        }
        if(level >= 10)
        {
            Bullet.bulletDamage++;
        }
    }
    public float GetTimeForCooldown()
    {
        return timeForCooldown;
    }
    public void Attack(Vector3 position, GameObject bullet, Transform shipTransform)
    {
        actualTurret.Attack(position, bullet, shipTransform);
    }
}
