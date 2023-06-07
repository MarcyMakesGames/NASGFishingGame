using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameTimeController gameTimeController;

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        gameTimeController.StartCountdown();
    }

    public void CountdownComplete()
    {
        //Score game
        //Display score
        //Display buttons for new game.
    }

    public void FishDepleted()
    {
        //Score game
        //Display score
        //Display buttons for new game.
    }

    private void Start()
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
}
