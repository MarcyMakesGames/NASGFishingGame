using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPoolController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FishPoolUIManager fishPoolUIManager;
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private Collider2D poolArea;
    
    [Header("Settings")]
    [SerializeField] private int maxFishCount;
    [SerializeField] private float rechargeInterval;

    private int availableFish;
    private float currentRechargeTimer;
    private GameObject currentSpawnedFish;
    private bool canRegenerateFish = true;
    private FishPoolUIController fishPoolUIController;

    private void Start()
    {
        availableFish = maxFishCount;
        currentRechargeTimer = rechargeInterval;

        if (fishPoolUIManager == null)
            Debug.Log("Oops.");

        fishPoolUIController = fishPoolUIManager.GetFishPoolUIElement(this.transform);
        UpdateSpawnerUI();

        GameManager.instance.AddNewFishPool();
    }

    private void Update()
    {
        RechargeCountdown();
        CheckSpawnFish();
    }

    private void RechargeCountdown()
    {
        if(availableFish == maxFishCount || !canRegenerateFish)
            return;

        currentRechargeTimer -= Time.deltaTime;

        if(currentRechargeTimer <= 0)
        {
            if(RegenerateFish())
            {
                currentRechargeTimer = rechargeInterval;
            }
        }
    }

    private bool RegenerateFish()
    {
        if(availableFish < maxFishCount)
        {
            availableFish++;
            UpdateSpawnerUI();

            return true;
        }

        return false;
    }

    private bool CheckSpawnFish()
    {
        if(currentSpawnedFish == null)
        {
            if(availableFish <= 0)
            {
                //Update game manager on no more fish.
                return false;
            }
            else
            {
                SpawnFish();
                return true;
            }
        }

        return false;
    }

    private void SpawnFish()
    {
        var point = new Vector2(
            Random.Range(poolArea.bounds.min.x, poolArea.bounds.max.x),
            Random.Range(poolArea.bounds.min.y, poolArea.bounds.max.y));

        GameObject newFish = Instantiate(fishPrefab, point, Quaternion.identity, this.transform);
        currentSpawnedFish = newFish;

        availableFish--;

        if(availableFish <= 0)
        {
            canRegenerateFish = false;
            Debug.Log("No more fish!");

            GameManager.instance.DepleteFishPool();
        }

        UpdateSpawnerUI();
    }

    private void UpdateSpawnerUI()
    {
        fishPoolUIController.UpdateUI(availableFish, maxFishCount);
    }
}
