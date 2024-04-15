using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportNorte : MonoBehaviour
{
    private Vector3 aux;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        aux = collision.transform.position;
        aux.y = (aux.y * -1f) + 1.2f;
        collision.transform.position = aux;
    }
}
