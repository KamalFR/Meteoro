using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShot : BaseForAttacks
{
    [SerializeField] private GameObject bullet;
    private Vector3 whereShot;
    private GameObject lastShot;
    public override void Attack(Vector3 position, GameObject bullet)
    {
        lastShot = Instantiate(bullet, (position + whereShot), Quaternion.identity);
        lastShot.GetComponent<Bullet>().SetMovimento(whereShot);
    }
    public override void SetWhereShot(Vector3 whereShot)
    {
        this.whereShot = whereShot;
    }
}
