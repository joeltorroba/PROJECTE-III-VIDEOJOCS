using UnityEngine;

public class VictorySpawner : MonoBehaviour
{
    public GameObject victoryPrefab;

    public float activationDistance = 20f;

    public float minX = -5f;
    public float maxX = 5f;

    public float minY = 0f;
    public float maxY = 200f;

    private Transform player;
    private bool hasSpawned = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // elegir posición random al empezar
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        transform.position = new Vector3(randomX, randomY, 0);
    }

    void Update()
    {
        if (hasSpawned) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < activationDistance)
        {
            SpawnVictoryObject();
            hasSpawned = true;
        }
    }

    void SpawnVictoryObject()
    {
        Instantiate(victoryPrefab, transform.position, Quaternion.identity);
    }
}