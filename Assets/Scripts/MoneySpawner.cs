using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject moneyPrefab;
    public Transform[] spawnPoints;

    [Header("Spawn Settings")]
    public int minMoneyPerBurst = 5;
    public int maxMoneyPerBurst = 10;

    public float spawnInterval = 3f;
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnMoneyBurst();
            timer = spawnInterval;
        }
    }

    void SpawnMoneyBurst()
    {
        int moneyToSpawn = Random.Range(minMoneyPerBurst, maxMoneyPerBurst + 1);

        for (int i = 0; i < moneyToSpawn; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Vector3 offset = new Vector3(
                Random.Range(-0.3f, 0.3f), // small random offset for variety
                Random.Range(-0.3f, 0.3f),
                0
            );

            Instantiate(moneyPrefab, spawnPoint.position + offset, Quaternion.identity);
        }
    }
}
