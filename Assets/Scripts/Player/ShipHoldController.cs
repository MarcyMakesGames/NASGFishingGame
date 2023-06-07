using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipHoldController : MonoBehaviour
{
    public int currentHoldCount;
    private int maxHoldCount;

    public void AddToShipHold()
    {
        if(currentHoldCount >= maxHoldCount)
        {
            //Don't add finish, punish the players.
            return;
        }

        //Update UI

        //Add to ship hold
    }

    public void ScoreShipHold()
    {
        //Update UI

        //Score ship hold

        currentHoldCount = 0;
    }

    public void InitShipHold(bool isCorporateShip)
    {
        
    }
}
