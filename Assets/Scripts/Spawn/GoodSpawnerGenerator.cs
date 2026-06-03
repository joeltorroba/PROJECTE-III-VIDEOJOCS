using UnityEngine;
using System.Collections.Generic;

public class GoodSpawnerGenerator : MonoBehaviour
{
    [Header("Spawner Prefab")]
    public GameObject goodSpawnerPrefab;

    [Header("Cantidad")]
    public int totalSpawners = 50;

    [Header("Altura maxima")]
    public float maxHeight = 300f;

    [Header("Limites X")]
    public float minX = -5f;
    public float maxX = 5f;

    [Header("Separacion minima")]
    public float minDistance = 5f;

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        GenerateSpawners();
    }

    void GenerateSpawners()
    {
        int created = 0;
        int attempts = 0;

        while (created < totalSpawners && attempts < totalSpawners * 20)
        {
            attempts++;

            Vector3 candidatePos = new Vector3(
                Random.Range(minX, maxX),
                Random.Range(0f, maxHeight),
                0f
            );

            bool valid = true;

            foreach (Vector3 existingPos in usedPositions)
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
                goodSpawnerPrefab,
                candidatePos,
                Quaternion.identity
            );

            usedPositions.Add(candidatePos);

            created++;
        }

        Debug.Log($"Good Spawners generados: {created}");
    }
}