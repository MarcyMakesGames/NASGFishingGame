using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreUIManager scoreUIManager;

    private List<PlayerObject> playerObjects;

    public void SpawnNewPlayer(int playerID, ShipHoldController shipHold)
    {
        PlayerObject newPlayer = new PlayerObject();

        switch(playerID)
        {
            case 0:
                newPlayer.playerID = PlayerID.Player1;
                break;

            case 1:
                newPlayer.playerID = PlayerID.Player2;
                break;

            case 2:
                newPlayer.playerID = PlayerID.Player3;
                break;

            case 3:
                newPlayer.playerID = PlayerID.Player4;
                break;

            default:
                return;
        }

        newPlayer.playerScore = 0;

        //Add to list
    }
    
    public void AddToScore(ShipHoldController playerHold)
    {
        foreach(PlayerObject player in playerObjects)
        {
            if(player.playerShipHold == playerHold)
            {
                player.playerScore++;
                //scoreUIController.UpdateScore(player.playerID, player.playerScore);
                return;
            }
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