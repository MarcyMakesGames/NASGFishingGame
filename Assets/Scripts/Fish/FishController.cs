using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minWaitTime;
    [SerializeField] private float maxWaitTime;
    [SerializeField] private int trashSpawnChance;
    [SerializeField] private GameObject trashPrefab;

    private Camera mainCamera;
    private Collider2D poolArea;
    private Vector3 targetPosition = Vector3.zero;
    private bool isDead = false;
    private bool isWaiting = false;
    private bool isGettingNewPosition = true;
    private float currentWaitTime;

    public void InitFishBoundaries(Collider2D collider)
    {
        poolArea = collider;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetTargetPosition();
        MoveAnimal();
        WaitAtPosition();
    }

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

    private void WaitAtPosition()
    {
        if (!isWaiting)
            return;

        currentWaitTime -= Time.deltaTime;

        if (currentWaitTime <= 0f)
        {
            isWaiting = false;
            isGettingNewPosition = true;
        }
    }

    private void MoveAnimal()
    {
        if (isDead || isWaiting || isGettingNewPosition)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isWaiting = true;
            currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    private void GetTargetPosition()
    {
        if (!isGettingNewPosition)
            return;            

        targetPosition = new Vector3(Random.Range(poolArea.bounds.min.x, poolArea.bounds.max.x),
                                     Random.Range(poolArea.bounds.min.y, poolArea.bounds.max.y), 0);
        isGettingNewPosition = false;

        if (targetPosition.x < transform.position.x)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
}
