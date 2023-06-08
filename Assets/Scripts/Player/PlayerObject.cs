using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject
{
    public PlayerID playerID;
    public int upgradeCount = 0;
    public MovementController playerMovement;
    public ShipHoldController playerShipHold;
    public PopUpUIController playerPopUp;
    public int playerScore;
}