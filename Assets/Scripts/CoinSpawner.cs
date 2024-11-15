using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 0.20f;  // Time between coin spawns
    public float spawnRangeX = 5.0f;     // Range of coin spawn positions on the X-axis
    public float spawnHeight = 1.0f;     // Height at which coins spawn (Y-axis)
    public float spawnZStart = 10.0f;    // Where to start spawning coins on the Z-axis
    public float stopZPosition = 50.0f;  // The Z position where coin spawning will stop

    private float spawnZ;  // Current Z position for coin spawning

    void Start()
    {
        spawnZ = spawnZStart; // Set the initial spawn position along the Z-axis
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (spawnZ < stopZPosition)  // Stop spawning if the Z position is greater than stopZPosition
        {
            yield return new WaitForSeconds(spawnInterval);

            // Randomly determine the X position within the defined range
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);

            // Increment Z to continuously spawn coins further along the road
            spawnZ += Random.Range(5.0f, 10.0f);  // Increment the spawnZ position

            // Instantiate a coin at the chosen position
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, spawnZ);
            GameObject spawnedCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            // Destroy the coin after 5 seconds
            Destroy(spawnedCoin, 20.0f);
        }
    }
}

