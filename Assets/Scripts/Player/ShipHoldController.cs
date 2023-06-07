using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipHoldController : MonoBehaviour
{
    [SerializeField] private int currentHoldCount;
    [SerializeField] private int maxHoldCount = 1;
    private PlayerID playerID;

    public bool AddToShipHold()
    {
        if(currentHoldCount >= maxHoldCount)
        {
            return false;
        }

        //Update UI

        currentHoldCount++;

        return true;
    }

    public void ScoreShipHold()
    {
        PlayerScoreManager.instance.AddToScore(playerID, currentHoldCount);
        //Score ship hold

        currentHoldCount = 0;
    }

    public void InitShipHold(PlayerID currentPlayer)
    {
        playerID = currentPlayer;
    }
}
