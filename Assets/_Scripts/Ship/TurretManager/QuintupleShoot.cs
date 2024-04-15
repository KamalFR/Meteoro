using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuintupleShoot : BaseForAttacks
{
    private GameObject lastShot;
    public override void Attack(Vector3 position, GameObject bullet, Transform shipTransform)
    {
        lastShot = Instantiate(bullet, (position + shipTransform.up), shipTransform.rotation);
        lastShot.GetComponent<Bullet>().SetMovimento();
        lastShot = Instantiate(bullet, (position + shipTransform.up / 2 + shipTransform.right), shipTransform.rotation);
        lastShot.GetComponent<Bullet>().SetMovimento();
        lastShot = Instantiate(bullet, (position + shipTransform.up / 2 - shipTransform.right), shipTransform.rotation);
        lastShot.GetComponent<Bullet>().SetMovimento();
        lastShot = Instantiate(bullet, (position + shipTransform.up * 0.75f + shipTransform.right / 2), shipTransform.rotation);
        lastShot.GetComponent<Bullet>().SetMovimento();
        lastShot = Instantiate(bullet, (position + shipTransform.up * 0.75f - shipTransform.right / 2), shipTransform.rotation);
        lastShot.GetComponent<Bullet>().SetMovimento();
    }
}
