using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShot : BaseForAttacks
{
    [SerializeField] private GameObject bullet;
    private GameObject lastShot;
    public override void Attack(Vector3 position, GameObject bullet, Transform shipTransform)
    {
        lastShot = Instantiate(bullet, (position + shipTransform.up), shipTransform.rotation);
        lastShot.GetComponent<Bullet>().SetMovimento();
    }
}
