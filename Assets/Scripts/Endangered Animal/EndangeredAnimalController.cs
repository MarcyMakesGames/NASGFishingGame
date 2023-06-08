using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndangeredAnimalController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minWaitTime;
    [SerializeField] private float maxWaitTime;

    private Camera mainCamera;
    private EndangeredAnimalSpawner animalSpawner;
    private Vector3 targetPosition = Vector3.zero;
    private bool isDead = false;
    private bool isWaiting = false;
    private bool isGettingNewPosition = true;
    private float currentWaitTime;

    public void InitEndangeredAnimal(EndangeredAnimalSpawner spawner)
    {
        animalSpawner = spawner;
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
            Debug.Log("Died.");
            isDead = true;
            deathParticles.Play();

            animalSpawner.EnableAnimalSpawn();
        }
    }

    private void WaitAtPosition()
    {
        if (!isWaiting)
            return;

        currentWaitTime -= Time.deltaTime;

        if(currentWaitTime <= 0f)
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

        if(transform.position == targetPosition)
        {
            isWaiting = true;
            currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    private void GetTargetPosition()
    {
        if (!isGettingNewPosition)
            return;

        Debug.Log("Getting new position");
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 bottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        Vector3 topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        targetPosition = new Vector3(Random.Range(bottomLeft.x, bottomRight.x), Random.Range(bottomLeft.y, topLeft.y), 0);
        isGettingNewPosition = false;

        if(targetPosition.x < transform.position.x)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
}
