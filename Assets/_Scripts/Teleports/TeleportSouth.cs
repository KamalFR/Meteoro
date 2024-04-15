using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSouth : MonoBehaviour
{
    private Vector3 aux;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aux = collision.transform.position;
        var nextTeleportCollider = FindObjectOfType<TeleportNorte>().GetComponent<Collider2D>();
        aux.y = (aux.y * -1f) - 1.2f;
        collision.transform.position = aux;
    }
}
