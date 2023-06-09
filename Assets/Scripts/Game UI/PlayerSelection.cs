using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private float countdownTime = 4f;

    private bool countDown = false;
    private float currentCountdown;
    private int currentSecond = 5;

    public delegate void onPlayersReady();
    public static event onPlayersReady OnPlayersReady;

    public void StartGame()
    {
        GameManager.instance.StartGame();
        OnPlayersReady?.Invoke();
    }

    private void Start()
    {
        playerInputManager.onPlayerJoined += OnPlayerSpawned;
        OnPlayersReady += DisablePlayerSelection;
        currentCountdown = countdownTime;
        statusText.text = "Waiting for players...";
    }

    private void Update()
    {
        Countdown();
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
                countDown = true;
                statusText.text = "Game begins in...";
                break;
            default:
                break;
        }
    }

    private void DisablePlayerSelection()
    {
        gameObject.SetActive(false);
    }

    private void Countdown()
    {
        if (!countDown)
            return;

        currentCountdown -= Time.deltaTime;

        UpdateCountdownText(currentCountdown);

        if(currentCountdown <= 0)
        {
            GameManager.instance.StartGame();
            OnPlayersReady?.Invoke();

            countDown = false;
        }
    }

    private void UpdateCountdownText(float timeLeft)
    {
        int secondsLeft = Mathf.FloorToInt(timeLeft);

        if(currentSecond != secondsLeft)
        {
            currentSecond = secondsLeft;
            countdownText.text = currentSecond.ToString();
        }
    }
}
