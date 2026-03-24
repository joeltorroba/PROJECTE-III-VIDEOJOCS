using UnityEngine;

public class GoodObjectSpawner : MonoBehaviour
{
    public GameObject[] goodPrefabs;   // Aquí metes Good_Slow y Good_Bounce
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

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < activationDistance)
        {
            SpawnObject();
            hasSpawned = true;
        }
    }

    void SpawnObject()
    {
        // Elegir prefab aleatorio
        int randomIndex = Random.Range(0, goodPrefabs.Length);

        // Posición con pequeño random en X
        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-2f, 2f);

        Instantiate(goodPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}