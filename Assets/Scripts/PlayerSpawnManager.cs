using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private PlayerStatsManager playerScoreManager;
    [SerializeField] private bool toggleSpawning = true;
    [SerializeField] private Sprite player1Sprite;
    [SerializeField] private Sprite player2Sprite;
    [SerializeField] private Sprite player3Sprite;
    [SerializeField] private Sprite player4Sprite;
    
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
                playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = player1Sprite;
                break;
            case 1:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player2).position;
                playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = player2Sprite;
                break;
            case 2:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player3).position;
                playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = player3Sprite;
                break;
            case 3:
                playerInput.gameObject.transform.position = FindObjectOfType<PortController>().GetPlayerSpawnPosition(PlayerID.Player4).position;
                playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = player4Sprite;
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
