using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipNormalAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private BaseForAttacks attack;
    private Rigidbody2D rb;
    private ShipMovement movement;
    private ShipControl input;
    private bool cooldownEnd;
    private float timeForCooldown;
    private float time;
    private void Awake()
    {
        attack = new BasicShot();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<ShipMovement>();
        input = new ShipControl();
        cooldownEnd = true;
        time = 0f;
        timeForCooldown = 1f;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Ship.NormalAttack.performed += OnAttack;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Ship.NormalAttack.performed -= OnAttack;
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        if (cooldownEnd)
        {
            attack.SetWhereShot(movement.GetLastMove());
            attack.Attack(rb.transform.position, bullet);
            cooldownEnd = false;
        }
    }
    private void Update()
    {
        if (!cooldownEnd)
        {
            time += Time.deltaTime;
            if (time >= timeForCooldown)
            {
                cooldownEnd = true;
                time = 0f;
            }
        }
    }
    public float GetTimeForCooldown()
    {
        return timeForCooldown;
    }
    public void SetTimeForCooldown(float newTime)
    {
        timeForCooldown = newTime;
    }
}
