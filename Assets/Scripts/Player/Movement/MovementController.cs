using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float shipMoveSpeed;
    [SerializeField] private Transform shipTransform;
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput == null)
            return;

        MoveShip(GetInput());
    }

    private Vector2 GetInput()
    {
        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();

        return moveVector;
    }

    private void MoveShip(Vector2 moveDir)
    {
        shipTransform.position += new Vector3(moveDir.x, moveDir.y, 0) * (shipMoveSpeed * Time.deltaTime);
    }
}