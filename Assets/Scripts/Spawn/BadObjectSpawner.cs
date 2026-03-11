using UnityEngine;

public class BadObjectSpawner : MonoBehaviour
{
    public GameObject badObjectPrefab;

    public float spawnInterval = 2f;
    public float spawnHeightOffset = 20f;

    public float minX = -8f;
    public float maxX = 8f;

    public float safeDistanceFromPlayer = 2f;

    private Transform player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        float randomX;

        do
        {
            randomX = Random.Range(minX, maxX);
        }
        while (Mathf.Abs(randomX - player.position.x) < safeDistanceFromPlayer);

        Vector3 spawnPos = new Vector3(
            randomX,
            player.position.y + spawnHeightOffset,
            player.position.z
        );

        Instantiate(badObjectPrefab, spawnPos, Quaternion.identity);
    }
}