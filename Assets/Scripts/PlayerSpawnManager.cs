using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private PlayerScoreManager playerScoreManager;
    private int playerIndex = 0;

    public int CurrentPlayerCount { get => playerIndex; }

    [ContextMenu("Spawn Player")]
    public void SpawnPlayer()
    {
        playerInputManager.JoinPlayer(playerIndex);
        playerIndex++;
    }

    public void OnPlayerSpawned(PlayerInput playerInput)
    {
        ShipHoldController shipHold = playerInput.GetComponent<ShipHoldController>();
        playerScoreManager.SpawnNewPlayer(playerInput.playerIndex, shipHold);
    }

    private void Awake()
    {
        playerInputManager.onPlayerJoined += OnPlayerSpawned;
    }
}
