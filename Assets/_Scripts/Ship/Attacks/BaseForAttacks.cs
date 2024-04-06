using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseForAttacks : MonoBehaviour
{
    public abstract void Attack(Vector3 position, GameObject type);
    public abstract void SetWhereShot(Vector3 whereShot);
}
