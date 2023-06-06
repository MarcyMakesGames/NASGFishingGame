using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ShipHoldController shipHoldController = other.gameObject.GetComponent<ShipHoldController>();

        if (shipHoldController != null)
        {
            shipHoldController.ScoreShipHold();
            Debug.Log("Player " + other.GetComponent<PlayerInput>().playerIndex + " entered port");
        }
    }
}
