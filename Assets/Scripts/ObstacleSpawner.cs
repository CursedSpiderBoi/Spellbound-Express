using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public GameObject[] obstaclePrefabs; // Assign your obstacle prefabs here
    public Transform spawnPoint;         // A point to the right of the screen where obstacles spawn
    public Vector2 spawnYRange = new Vector2(-3f, 3f);

    [Header("Spawn Timing")]
    public float startSpawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float spawnAcceleration = 0.01f; // How much faster spawning gets over time

    private float currentSpawnInterval;
    private float spawnTimer;

    private void Start()
    {
        currentSpawnInterval = startSpawnInterval;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f;

            // Gradually speed up spawn rate
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnAcceleration);
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0 || spawnPoint == null)
        {
            Debug.LogWarning("ObstacleSpawner: No prefabs or spawn point set!");
            return;
        }

        int index = Random.Range(0, obstaclePrefabs.Length);
        float spawnY = Random.Range(spawnYRange.x, spawnYRange.y);
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnY, 0f);

        Instantiate(obstaclePrefabs[index], spawnPosition, Quaternion.identity);
    }
}
