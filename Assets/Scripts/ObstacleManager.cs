using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] stagePrefabs;
    public GameObject playerObj;

    public int Score = 0;
    public int bestScore;

    int stageCount;

    int playerDistanceIndex = -1;
    int stageIndex = 0;
    int distanceToNext = 10;

    int randStage;

    void Start()
    {
        stageCount = stagePrefabs.Length;

    }

    void Update()
    {
        int playerDistance = (int)(playerObj.transform.position.y / (distanceToNext / 2));
        if (playerDistanceIndex != playerDistance)
        {
            InstantiateStages();
            playerDistanceIndex = playerDistance;
        }
    }

    public void InstantiateStages()
    {
        randStage = Random.Range(0, stagePrefabs.Length);
        GameObject newStage = Instantiate(stagePrefabs[randStage], new Vector3(0, stageIndex * distanceToNext), Quaternion.identity);
        newStage.transform.SetParent(transform);
        stageIndex++;
    }
}
