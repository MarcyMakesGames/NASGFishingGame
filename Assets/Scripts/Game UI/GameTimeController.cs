using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeController : MonoBehaviour
{
    [SerializeField] private GameTimeUIController gameTimeUIController;
    [SerializeField] private int roundTime;

    private float currentRoundTime;
    private int updateTime;
    private bool countdownStarted = false;

    public void StartCountdown()
    {
        countdownStarted = true;
    }

    private void Start()
    {
        currentRoundTime = roundTime;
        updateTime = Mathf.Clamp(Mathf.RoundToInt(currentRoundTime) - 1, 0, roundTime);
        gameTimeUIController.UpdateUI((int)currentRoundTime);
    }

    private void Update()
    {
        if(countdownStarted)
            CountdownRound();
    }

    private void CountdownRound()
    {
        currentRoundTime -= Time.deltaTime;

        if(currentRoundTime <= updateTime)
        {
            if(currentRoundTime <= 0)
            {
                countdownStarted = false;
                CountdownComplete();
            }

            updateTime = Mathf.Clamp(Mathf.RoundToInt(currentRoundTime) - 1, 0, roundTime);
            gameTimeUIController.UpdateUI(updateTime);
        }
    }

    private void CountdownComplete()
    {
        GameManager.instance.CountdownComplete();
    }
}
