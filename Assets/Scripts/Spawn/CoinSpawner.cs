using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject coinPrefab;

    [Header("Cantidad")]
    public int totalCoins = 100;

    [Header("Altura maxima")]
    public float maxHeight = 300f;

    [Header("Limites X")]
    public float minX = -5f;
    public float maxX = 5f;

    [Header("Separacion minima")]
    public float minDistance = 2f;

    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        int created = 0;
        int attempts = 0;

        while (created < totalCoins && attempts < totalCoins * 20)
        {
            attempts++;

            Vector3 candidatePos = new Vector3(
                Random.Range(minX, maxX),
                Random.Range(0f, maxHeight),
                0f
            );

            bool valid = true;

            foreach (Vector3 existingPos in spawnedPositions)
            {
                if (Vector3.Distance(candidatePos, existingPos) < minDistance)
                {
                    valid = false;
                    break;
                }
            }

            if (!valid)
                continue;

            Instantiate(
                coinPrefab,
                candidatePos,
                Quaternion.identity
            );

            spawnedPositions.Add(candidatePos);
            created++;
        }

        Debug.Log($"Chapas generadas: {created}");
    }
}