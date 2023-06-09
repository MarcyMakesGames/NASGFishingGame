using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class MovementController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float shipMoveSpeed;
    [SerializeField] private float upgradeMoveSpeed;
    [SerializeField] private Transform shipTransform;
    [SerializeField] private AudioSource audioSource;

    private PlayerInput playerInput;
    private bool gameStarted = false;
    private bool playingAudio = false;

    public void UpgradeMoveSpeed()
    {
        shipMoveSpeed += upgradeMoveSpeed;
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.uiInputModule = FindObjectOfType<InputSystemUIInputModule>();
        PlayerSelection.OnPlayersReady += EnablePlayerMovement;
    }

    private void Update()
    {
        if (playerInput == null || !gameStarted)
            return;

        MoveShip(GetMoveInput());
        TakeAction();
        PlayAudio();
    }

    private void PlayAudio()
    {
        if(!playingAudio)
        {
            audioSource.Stop();
            return;
        }
        else
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
    }

    private void EnablePlayerMovement()
    {
        gameStarted = true;
    }

    private Vector2 GetMoveInput()
    {
        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();

        if(moveVector.x > 0)
            spriteRenderer.flipX = false;
        else if(moveVector.x < 0)
            spriteRenderer.flipX = true;

        return moveVector;
    }

    private void MoveShip(Vector2 moveDir)
    {
        if(moveDir == Vector2.zero)
        {
            playingAudio = false;
            return;
        }

        playingAudio = true;
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