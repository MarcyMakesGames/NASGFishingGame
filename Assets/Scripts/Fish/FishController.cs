using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipHoldController scoreController = collision.gameObject.GetComponent<ShipHoldController>();

        if (scoreController != null)
        {
            if (scoreController.AddToShipHold())
                Destroy(gameObject);
            else
                scoreController = null;
        }
    }
}
