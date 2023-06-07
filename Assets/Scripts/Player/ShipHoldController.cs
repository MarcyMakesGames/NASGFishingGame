using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipHoldController : MonoBehaviour
{
    [SerializeField] private int currentHoldCount;
    [SerializeField] private int maxHoldCount = 1;
    [SerializeField] private int upgradeHoldCount = 1;
    [SerializeField] private float shipSizeIncrease = 0.1f;
    [SerializeField] private int massIncrease = 1;
    [SerializeField] private Rigidbody2D shipRigidBody;
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
        if(currentHoldCount <= 0)
            return;
        PlayerStatsManager.instance.AddToScore(playerID, currentHoldCount);

        currentHoldCount = 0;
        PlayerStatsManager.instance.UpdateCargoHoldUI(playerID, currentHoldCount, maxHoldCount);
    }

    public void InitShipHold(PlayerID currentPlayer)
    {
        playerID = currentPlayer;
    }

    public void UpgradeShipHold()
    {
        maxHoldCount += upgradeHoldCount;
        transform.localScale = transform.localScale + new Vector3(shipSizeIncrease, shipSizeIncrease, shipSizeIncrease);
        shipRigidBody.mass += massIncrease;
    }
}
