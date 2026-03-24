using UnityEngine;

public class GoodObjectSpawner : MonoBehaviour
{
    public GameObject[] goodPrefabs;
    public float activationDistance = 15f;

    private Transform player;
    private bool hasSpawned = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (hasSpawned) return;

        float distance = Mathf.Abs(player.position.y - transform.position.y);

        if (distance < activationDistance)
        {
            SpawnObject();
            hasSpawned = true;
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, goodPrefabs.Length);

        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-2f, 2f);

        Instantiate(goodPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}