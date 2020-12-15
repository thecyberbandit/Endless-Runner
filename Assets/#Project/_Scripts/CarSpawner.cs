using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public ObjectPooler objectPooler;


    public void SpawnCars(Transform[] points)
    {
        GameObject car1 = objectPooler.GetPooledObject();
        car1.transform.position = points[0].transform.position;
        car1.SetActive(true);

        GameObject car2 = objectPooler.GetPooledObject();
        car2.transform.position = points[0].transform.position;
        car2.SetActive(true);
    }
}
