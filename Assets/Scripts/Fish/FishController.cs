using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] private int trashSpawnChance;
    [SerializeField] private GameObject trashPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipHoldController scoreController = collision.gameObject.GetComponent<ShipHoldController>();

        if (scoreController != null)
        {
            if (scoreController.AddToShipHold())
            {
                var rollForTrash = Random.Range(0, 100);
                if (rollForTrash <= trashSpawnChance)
                {
                    GameObject go = Instantiate(trashPrefab);
                    go.transform.position = transform.position;
                }

                Destroy(gameObject);
            }
            else
                scoreController = null;
        }
    }
}
