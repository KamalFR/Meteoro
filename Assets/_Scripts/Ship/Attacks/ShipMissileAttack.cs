using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMissileAttack : MonoBehaviour
{
    [SerializeField] private GameObject missile;
    private MissileControl rocket;
    private Rigidbody2D rb;
    private ShipControl input;
    private bool cooldownEnd;
    private float time;
    private void Awake()
    {
        rocket = new MissileControl();
        rb = GetComponent<Rigidbody2D>();
        input = new ShipControl();
        cooldownEnd = true;
        time = 0f;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Ship.RocketAttack.performed += OnAttack;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Ship.RocketAttack.performed -= OnAttack;
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        if (cooldownEnd)
        {
            rocket.Attack(rb.transform.position, missile, transform);
            cooldownEnd = false;
        }
    }
    private void Update()
    {
        if (!cooldownEnd)
        {
            time += Time.deltaTime;
            if (time >= rocket.GetTimeForCooldown())
            {
                cooldownEnd = true;
                time = 0f;
            }
        }
    }
    public void UpgradeMissile()
    {
        rocket.UpgradeMissile();
    }
}
