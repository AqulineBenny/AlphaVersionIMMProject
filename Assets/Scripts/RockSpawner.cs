using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;         // Reference to the rock prefab
    public float spawnInterval = 0.05f;    // Interval between rock spawns (adjust for faster appearance)
    public float spawnRangeX = 5.0f;      // Range of spawn positions on the X-axis
    public float spawnHeight = 1.0f;      // Height at which rocks spawn (Y-axis)
    public float spawnZStart = 10.0f;     // Where to start spawning rocks on the Z-axis
    public float stopZPosition = 180.0f;  // Z position to stop spawning obstacles
    public int totalObstacles = 10;       // The total number of obstacles to spawn

    private float spawnZ;  // Current Z position for spawning rocks
    private int obstacleCount = 0;  // To track how many obstacles have been spawned

    void Start()
    {
        spawnZ = spawnZStart;  // Set initial spawn position along the Z-axis
        StartCoroutine(SpawnRocks());
    }

    IEnumerator SpawnRocks()
    {
        // Loop until we have spawned the total number of obstacles
        while (obstacleCount < totalObstacles)
        {
            yield return new WaitForSeconds(spawnInterval);  // Wait for the interval before the next spawn

            // Randomly determine the X position within the defined range
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);

            // Increment Z to spawn the rock further along the road (but stop at 180)
            spawnZ += Random.Range(15.0f, 20.0f);  // Spacing out the obstacles a bit

            // Ensure that spawnZ doesn't exceed stopZPosition
            if (spawnZ > stopZPosition)
                break;

            // Instantiate a rock at the chosen position
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, spawnZ);
            GameObject spawnedRock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);

            // Destroy the rock after a set time (to avoid cluttering the scene)
            Destroy(spawnedRock, 8.0f);

            // Increment the obstacle count
            obstacleCount++;
        }
    }
}
