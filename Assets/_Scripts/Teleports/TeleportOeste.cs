using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOeste : MonoBehaviour
{
    private Vector3 aux;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        aux = collision.transform.position;
        aux.x += 8.3f * 2;
        collision.transform.position = aux;
    }
}
