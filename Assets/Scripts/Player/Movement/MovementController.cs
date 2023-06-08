using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float shipMoveSpeed;
    [SerializeField] private float upgradeMoveSpeed;
    [SerializeField] private Transform shipTransform;

    private PlayerInput playerInput;

    public void UpgradeMoveSpeed()
    {
        shipMoveSpeed += upgradeMoveSpeed;
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("UI");
        playerInput.uiInputModule = FindObjectOfType<InputSystemUIInputModule>();
    }

    private void Update()
    {
        if (playerInput == null)
            return;

        MoveShip(GetMoveInput());
        TakeAction();
    }

    private Vector2 GetMoveInput()
    {
        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();
        

        return moveVector;
    }

    private void MoveShip(Vector2 moveDir)
    {
        shipTransform.position += new Vector3(moveDir.x, moveDir.y, 0) * (shipMoveSpeed * Time.deltaTime);
    }

    private void TakeAction()
    {
        if (playerInput.actions["Action"].triggered)
        {
            Debug.Log("Action triggered");
        }
    }
}