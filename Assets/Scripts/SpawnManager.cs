using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targetPrefabs = new List<GameObject>();
    private float xSpawnRange = 3.5f;
    private float ySpawnRange = 1.5f;
    [SerializeField] float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        int targetTypeIndex = SetTargetType();
        Vector3 spawnPosition = CreateRandomPosition();
        GameObject targetPrefab = targetPrefabs[targetTypeIndex];

        GameObject.Instantiate(targetPrefab, spawnPosition, targetPrefab.transform.rotation);
    }

    private int SetTargetType()
    {
        int targetTypesAmount = targetPrefabs.Count();
        int normalChance = Random.Range(0, 3);
        if (normalChance == 0) // 25% for special target
        {
            return Random.Range(0, targetTypesAmount - 1) + 1; //return range from 1 to targetTypesAmount;
        }
        else
        {
            return 0;
        }
    }

    Vector3 CreateRandomPosition()
    {
        float xPosition = Random.Range(-xSpawnRange, xSpawnRange);
        float yPosition = Random.Range(-ySpawnRange, ySpawnRange);
        return new Vector3(xPosition, yPosition, 0);
    }
}
