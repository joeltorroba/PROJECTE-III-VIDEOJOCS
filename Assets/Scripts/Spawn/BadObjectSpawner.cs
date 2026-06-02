using UnityEngine;

public class BadObjectSpawner : MonoBehaviour
{
    public GameObject[] badObjectPrefabs;

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
        if (TimeFreezeSystem.timeFrozen)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        if (badObjectPrefabs == null || badObjectPrefabs.Length == 0)
            return;

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

        int randomIndex = Random.Range(0, badObjectPrefabs.Length);

        Instantiate(
            badObjectPrefabs[randomIndex],
            spawnPos,
            Quaternion.identity
        );
    }
}