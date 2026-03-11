using UnityEngine;

public class GoodObjectSpawner : MonoBehaviour
{
    public GameObject goodObjectPrefab;
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
        Instantiate(goodObjectPrefab, transform.position, Quaternion.identity);
    }
}