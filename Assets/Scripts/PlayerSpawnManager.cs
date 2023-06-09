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

    private void OnPlayerSpawned(PlayerInput playerInput)
    {
        Debug.Log("Spawning new player.");
        ShipHoldController shipHold = playerInput.GetComponent<ShipHoldController>();
        MovementController shipMove = playerInput.GetComponent<MovementController>();
        PopUpUIController popUp = playerInput.GetComponentInChildren<PopUpUIController>();

        switch(playerInput.playerIndex)
        {
            case 0:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player1).position;
                break;
            case 1:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player2).position;
                break;
            case 2:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player3).position;
                break;
            case 3:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player4).position;
                break;
            default:
                break;
        }

        playerScoreManager.InitNewPlayer(playerInput.playerIndex, shipHold, shipMove, popUp);
    }

    private void Awake()
    {
        playerInputManager.onPlayerJoined += OnPlayerSpawned;
    }
}
