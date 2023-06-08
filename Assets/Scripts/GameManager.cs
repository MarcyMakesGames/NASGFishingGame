using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        //Score game
        //Display score
        //Display buttons for new game.
        GOController.ShowGameOverUI(10000, "Hello World");
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

    private void Start()
    {
        StartGame();
    }

    private void AllFishDepleted()
    {
        Debug.Log("All the fish are dead!");

        //Score game
        //Display score
        //Display buttons for new game.
    }
}
