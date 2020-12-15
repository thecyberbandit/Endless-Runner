using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler objectPooler;
    public int coinsPerLevel = 3;



    public void SpawnCoin(List<Transform> spawnPoints)
    {
        for (int i = 0; i < coinsPerLevel; i++)
        {
            if (spawnPoints.Count > 0)
            {
                int r = Random.Range(0, spawnPoints.Count);

                Debug.Log(r);

                Vector3 coinPosition = spawnPoints[r].position;

                GameObject newCoin = objectPooler.GetPooledObject();

                newCoin.transform.position = coinPosition;
                newCoin.SetActive(true);

                spawnPoints.RemoveAt(r);
            }
        }
    }
}
