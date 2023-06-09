using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;

    public delegate void onPlayersReady();
    public static event onPlayersReady OnPlayersReady;

    private void Start()
    {
        playerInputManager.onPlayerJoined += OnPlayerSpawned;
        OnPlayersReady += DisablePlayerSelection;
    }

    private void OnPlayerSpawned(PlayerInput playerInput)
    {
        switch (playerInput.playerIndex)
        {
            case 0:
                player1.SetActive(true);
                break;
            case 1:
                player2.SetActive(true);
                break;
            case 2:
                player3.SetActive(true);
                break;
            case 3:
                player4.SetActive(true);
                GameManager.instance.StartGame();
                OnPlayersReady?.Invoke();
                break;
            default:
                break;
        }
    }

    private void DisablePlayerSelection()
    {
        gameObject.SetActive(false);
    }
}
