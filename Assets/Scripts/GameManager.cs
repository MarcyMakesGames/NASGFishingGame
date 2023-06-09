using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PlayerStatsManager playerStatsManager;
    [SerializeField] private GameTimeController gameTimeController;
    [SerializeField] private GameOverController GOController;

    private int fishPoolCount = 0;

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        gameTimeController.StartCountdown();
    }

    public void AddNewFishPool()
    {
        fishPoolCount++;
    }

    public void DepleteFishPool()
    {
        fishPoolCount--;

        if(fishPoolCount <= 0)
            AllFishDepleted();
    }

    public void CountdownComplete()
    {
        List<PlayerID> list = ScoreGame();
        GOController.ShowGameOverUI(list);
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Game manager already exists.");
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void AllFishDepleted()
    {
        List<PlayerID> list = ScoreGame();
        GOController.ShowGameOverUI(list);
    }
    
    private List<PlayerID> ScoreGame()
    {
        List<PlayerObject> playerObjects = playerStatsManager.PlayerObjects;

        int highestScore = 0;

        foreach(PlayerObject player in playerObjects)
        {
            if(player.playerScore > highestScore)
            {
                highestScore = player.playerScore;
            }
        }

        List<PlayerID> winners = new List<PlayerID>();

        foreach(PlayerObject player in playerObjects)
        {
            if(player.playerScore >= highestScore)
            {
                winners.Add(player.playerID);
            }
        }

        return winners;
    }
}
