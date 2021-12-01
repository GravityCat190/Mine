using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    private float xSpawnRange = 3.5f;
    private float ySpawnRange = 1.5f;
    private float baseSpawnInterval;

    [SerializeField] float spawnInterval;
    [SerializeField] List<GameObject> targetPrefabs = new List<GameObject>();
    [SerializeField] private ComboManager ComboManager;
    [SerializeField] int maxTargetAmount;

    private int lastType;

    // Start is called before the first frame update
    void Start()
    {
        baseSpawnInterval = spawnInterval;
        Invoke("SpawnTarget", 0);
    }

    void SpawnTarget()
    {
        int targetTypeIndex = SetTargetType();
        GameObject targetPrefab = targetPrefabs[targetTypeIndex];

        Vector3 spawnPosition = CreateRandomPosition();

        CreateObject(targetPrefab, spawnPosition);

        float divider = 1 + ComboManager.GetCurrentCombo()/5;
        spawnInterval = baseSpawnInterval/divider;
        Invoke("SpawnTarget", spawnInterval);
    }

    void CreateObject(GameObject targetPrefab, Vector3 spawnPosition)
    {
        int targetAmountOnMap = GameObject.FindObjectsOfType<Target>().Length;
        if (targetAmountOnMap <= maxTargetAmount)
        {
            GameObject.Instantiate(targetPrefab, spawnPosition, targetPrefab.transform.rotation);
        }
    }

    private int SetTargetType()
    {
        int normalChance = Random.Range(0, 3);
        int type;

        if (normalChance == 0) // 25% for special target
        {
            type = GetSpecialType();
        }
        else
        {
            type = 0;
        }

        lastType = type;
        return type;
    }

    private int GetSpecialType()
    {
        int targetTypesAmount = targetPrefabs.Count();
        int type = Random.Range(0, targetTypesAmount - 1) + 1; //return range from 1 to targetTypesAmount;
        while (type == lastType)
        {
            type = GetSpecialType();
        }
        return type;
    }

    Vector3 CreateRandomPosition()
    {
        float xPosition = Random.Range(-xSpawnRange, xSpawnRange);
        float yPosition = Random.Range(-ySpawnRange, ySpawnRange);
        return new Vector3(xPosition, yPosition, 0);
    }
}
