using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortController : MonoBehaviour
{
    [SerializeField] private Transform player1Position;
    [SerializeField] private Transform player2Position;
    [SerializeField] private Transform player3Position;
    [SerializeField] private Transform player4Position;

    public Transform GetPlayerSpawnPosition(PlayerID player)
    {
        switch (player)
        {
            case PlayerID.Player1:
                return player1Position;
            case PlayerID.Player2:
                return player2Position;
            case PlayerID.Player3:
                return player3Position;
            case PlayerID.Player4:
                return player4Position;
        }

        return null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ShipHoldController shipHoldController = other.gameObject.GetComponent<ShipHoldController>();

        if (shipHoldController != null)
        {
            shipHoldController.ScoreShipHold();
        }
    }
}
