using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;

    [SerializeField] private ScoreUIManager scoreUIManager;
    [SerializeField] private CargoCapacityUIController cargoCapacityUIController;

    private List<PlayerObject> playerObjects;

    public void InitNewPlayer(int playerID, ShipHoldController shipHold)
    {
        PlayerObject newPlayer = new PlayerObject();

        switch(playerID)
        {
            case 0:
                newPlayer.playerID = PlayerID.Player1;
                shipHold.InitShipHold(PlayerID.Player1);
                break;

            case 1:
                newPlayer.playerID = PlayerID.Player2;
                shipHold.InitShipHold(PlayerID.Player2);
                break;

            case 2:
                newPlayer.playerID = PlayerID.Player3;
                shipHold.InitShipHold(PlayerID.Player3);
                break;

            case 3:
                newPlayer.playerID = PlayerID.Player4;
                shipHold.InitShipHold(PlayerID.Player4);
                break;

            default:
                return;
        }

        Debug.Log("New Player:" + newPlayer.playerID.ToString());
        newPlayer.playerScore = 0;

        if(playerObjects == null)
        {
            playerObjects = new List<PlayerObject>();
        }

        playerObjects.Add(newPlayer);
    }
    
    public void AddToScore(PlayerID currentPlayer, int scoreToAdd)
    {
        foreach(PlayerObject player in playerObjects)
        {
            if(player.playerID == currentPlayer)
            {
                player.playerScore += scoreToAdd;
                scoreUIManager.UpdateScore(player.playerID, player.playerScore);
                return;
            }
        }

        Debug.Log("No ship hold found.");
    }

    public void UpdateCargoHoldUI(PlayerID currentPlayer, int currentCargo, int maxCargo)
    {
        cargoCapacityUIController.UpdateUI(currentPlayer, currentCargo, maxCargo);
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

public class PlayerObject
{
    public PlayerID playerID;
    public ShipHoldController playerShipHold;
    public int playerScore;   
}

public enum PlayerID
{
    Player1,
    Player2,
    Player3,
    Player4
}