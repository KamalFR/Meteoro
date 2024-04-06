using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private ShipControl input;
    private Vector3 lastMove;
    //private bool change;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new ShipControl();
        lastMove = new Vector3(1, 0, 0);
        //change = false;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Ship.Move.performed += OnMove;
        input.Ship.Move.started += OnMove;
        input.Ship.Move.canceled += OnMove;

    }
    private void OnDisable()
    {
        input.Disable();
        input.Ship.Move.performed -= OnMove;
        input.Ship.Move.started -= OnMove;
        input.Ship.Move.canceled -= OnMove;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector3 movementDirection = context.ReadValue<Vector2>();
        rb.velocity = new Vector3(movementDirection.x, movementDirection.y, 0f) * speed;
        SetLastMove(movementDirection);
    }
    private void SetLastMove(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            lastMove = movementDirection;
        }
    }
    public Vector3 GetLastMove()
    {
        return lastMove;
    }
}
