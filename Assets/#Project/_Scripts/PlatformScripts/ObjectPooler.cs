using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject[] pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;


    void Start()
    {
        pooledObjects = new List<GameObject>();
        AddObjects();
    }

    void AddObjects()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            //int r = Random.Range(0, pooledObject.Length);
            //Debug.Log(r);
            GameObject obj = (GameObject)Instantiate(pooledObject[i]);
            //obj.GetComponent<MeshRenderer>().enabled = false;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //if (!pooledObjects[i].GetComponent<MeshRenderer>().enabled)
            //{
            //    return pooledObjects[i];
            //}

            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        int r = Random.Range(0, pooledObject.Length);
        //Debug.Log(r);
        GameObject obj = (GameObject)Instantiate(pooledObject[r]);
        //obj.GetComponent<MeshRenderer>().enabled = false;
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
