using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAttack : BaseForAttacks
{
    private GameObject lastShot;
    public override void Attack(Vector3 position, GameObject missile, Transform shipTransform)
    {
        lastShot = Instantiate(missile, (position + shipTransform.up), shipTransform.rotation);
        lastShot.GetComponent<Missile>().SetMovimento();
    }
}
