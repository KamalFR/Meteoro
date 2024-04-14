using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private ShipControl input;
    private Vector3 lastMove;
    private bool rotate;
    private bool move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new ShipControl();
        lastMove = new Vector3(1, 0, 0);
        rotate = false;
        move = false;
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
        if (movementDirection.y == 0)
        {
            rb.velocity = Vector3.zero;
            move = false;
        }
        else
        {
            move = true;
        }
        if (movementDirection.x != 0f)
        {
            rotate = true;
        }
        else
        {
            rotate = false;
        }
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
    private void Rotate()
    {
        if(lastMove.x < 0)
        {
            GetComponent<Transform>().Rotate(0f, 0f, 2f);
        }
        else
        {
            GetComponent<Transform>().Rotate(0f, 0f, -2f);
        }
    }
    private void Update()
    {
        if (rotate)
        {
            Rotate();
        }
        if (move)
        {
            Move();
        }
    }
    private void Move()
    {
        if(lastMove.y > 0f)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.up * speed*-1;
        }
    }
}
