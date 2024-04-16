using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOeste : MonoBehaviour
{
    private Vector3 aux;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        aux = collision.transform.position;
        aux.x = (aux.x * -1f) - 1.2f;
        collision.transform.position = aux;
    }
}
