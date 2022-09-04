using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    private int spawnRadius = 20;
    private int spawnAmount = 5;

    private void Start()
    {
        SpawnInitialAsteroids();
    }

    private void SpawnInitialAsteroids()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 randomSpawnPoint = Random.insideUnitCircle * spawnRadius;
            Instantiate(asteroidPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }

}
