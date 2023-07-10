using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] spawnWaypoints;
    public float spawnInterval = 2f;    // Time interval between spawns

    private void Start()
    {
        // Start the coroutine to spawn objects
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnObjectAtRandomWaypoint();

            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    public void SpawnObjectAtRandomWaypoint()
    {
        // Select a random waypoint index
        int randomIndex = Random.Range(0, spawnWaypoints.Length);

        // Get the random waypoint position
        Vector3 randomPosition = spawnWaypoints[randomIndex].position;

        // Spawn the object at the random waypoint position
        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }

}
