using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSouth : MonoBehaviour
{
    private Vector3 aux;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        aux = collision.transform.position;
        aux.y += 4.4f*2;
        collision.transform.position = aux;
    }
}
