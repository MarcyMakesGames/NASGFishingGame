using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private PlayerStatsManager playerScoreManager;
    [SerializeField] private bool toggleSpawning = true;
    
    [ContextMenu("Toggle Spawning")]
    public void ToggleSpawning()
    {
        TogglePlayerSpawning(toggleSpawning);
    }

    public void TogglePlayerSpawning(bool enableSpawning)
    {
        if(enableSpawning)
            playerInputManager.EnableJoining();
        else
            playerInputManager.DisableJoining();
    }

    public void OnPlayerSpawned(PlayerInput playerInput)
    {
        Debug.Log("Spawning new player.");
        ShipHoldController shipHold = playerInput.GetComponent<ShipHoldController>();
        MovementController shipMove = playerInput.GetComponent<MovementController>();
        PopUpUIController popUp = playerInput.GetComponentInChildren<PopUpUIController>();
        playerScoreManager.InitNewPlayer(playerInput.playerIndex, shipHold, shipMove, popUp);
    }

    private void Awake()
    {
        playerInputManager.onPlayerJoined += OnPlayerSpawned;
    }
}
