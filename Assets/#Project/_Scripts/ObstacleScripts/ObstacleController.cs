using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public ObjectPooler objectPooler;
    public int obstaclesPerLevel = 3;


    public void SpawnObstacle(List<Transform> spawnPoints)
    {
        for (int i = 0; i < obstaclesPerLevel; i++)
        {
            if (spawnPoints.Count > 0)
            {
                int r = Random.Range(0, spawnPoints.Count);

                Debug.Log(r);

                Vector3 obstaclePosition = spawnPoints[r].position;

                GameObject newObstacle = objectPooler.GetPooledObject();

                newObstacle.transform.position = obstaclePosition;
                newObstacle.SetActive(true);

                spawnPoints.RemoveAt(r);
            }
        }
    }
}
