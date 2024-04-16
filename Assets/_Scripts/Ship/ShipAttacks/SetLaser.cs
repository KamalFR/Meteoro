using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLaser : MonoBehaviour
{
    private float time;
    private void Update()
    {
        time += Time.deltaTime;
        if(time > 0.1f)
        {
            Destroy(gameObject);
        }
    }
    public void SetLaserSize(float distance)
    {
        time = 0f;
        Vector3 size = new Vector3(1, distance / 1.7f, 1);
        transform.localScale = size;
    }
}
