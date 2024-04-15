using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipNormalAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private TurretControl turret;
    private Rigidbody2D rb;
    private ShipControl input;
    private bool cooldownEnd;
    private float time;
    private void Awake()
    {
        turret = new TurretControl();
        rb = GetComponent<Rigidbody2D>();
        input = new ShipControl();
        cooldownEnd = true;
        time = 0f;
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
            turret.Attack(rb.transform.position, bullet, transform);
            cooldownEnd = false;
        }
    }
    private void Update()
    {
        if (!cooldownEnd)
        {
            time += Time.deltaTime;
            if (time >= turret.GetTimeForCooldown())
            {
                cooldownEnd = true;
                time = 0f;
            }
        }
    }
    public void UpgradeTorret()
    {
        turret.UpgradeTurret();
    }
}
