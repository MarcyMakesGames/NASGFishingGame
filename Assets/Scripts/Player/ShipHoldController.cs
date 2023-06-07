using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipHoldController : MonoBehaviour
{
    [SerializeField] private int currentHoldCount;
    [SerializeField] private int maxHoldCount = 1;
    private PlayerID playerID;

    public int CurrentCargo { get => currentHoldCount; }
    public int MaxCargo { get => maxHoldCount; }

    public bool AddToShipHold()
    {
        if(currentHoldCount >= maxHoldCount)
        {
            return false;
        }

        currentHoldCount++;
        PlayerStatsManager.instance.UpdateCargoHoldUI(playerID, currentHoldCount, maxHoldCount);

        return true;
    }

    public void ScoreShipHold()
    {
        PlayerStatsManager.instance.AddToScore(playerID, currentHoldCount);
        //Score ship hold

        currentHoldCount = 0;
        PlayerStatsManager.instance.UpdateCargoHoldUI(playerID, currentHoldCount, maxHoldCount);
    }

    public void InitShipHold(PlayerID currentPlayer)
    {
        playerID = currentPlayer;
    }
}
