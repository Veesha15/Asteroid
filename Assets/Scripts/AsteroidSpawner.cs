using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;
    private int spawnRadius = 20;
    private int spawnAmount = 10;

    private void Start()
    {
        SpawnNewAsteroids();
    }

    private void SpawnNewAsteroids()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 randomSpawnPoint = Random.insideUnitCircle * spawnRadius;
            Instantiate(asteroidPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }

}
