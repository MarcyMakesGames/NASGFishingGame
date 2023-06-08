using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndangeredAnimalSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private GameObject animalPrefab;

    private float spawnTimer;
    private bool canSpawn = false;

    public void EnableAnimalSpawn()
    {
        canSpawn = true;
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        canSpawn = true;
    }

    private void Update()
    {
        SpawnNewAnimal();
    }

    private void SpawnNewAnimal()
    {
        if(canSpawn)
        {
            spawnTimer -= Time.deltaTime;

            if(spawnTimer <= 0)
            {
                GameObject go = Instantiate(animalPrefab, transform.position, Quaternion.identity);
                go.GetComponent<EndangeredAnimalController>().InitEndangeredAnimal(this);

                canSpawn = false;
            }
        }
    }
}
