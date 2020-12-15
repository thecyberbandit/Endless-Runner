using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

    public Vector3 lastPosition;
    public float pathOffset = 10f;
    public ObjectPooler objectPooler;

    [HideInInspector]
    public int pathCount;


    void Update()
    {
        if (GameManager.instance.canAppear)
        {
            CreateNewPath();
        }
    }


    public void CreateNewPath()
    {
        GameObject newPlatform = objectPooler.GetPooledObject();
        newPlatform.transform.position = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z + pathOffset);
        //Debug.Log(newPlatform.transform.position);
        //newPlatform.GetComponent<MeshRenderer>().enabled = true;
        newPlatform.SetActive(true);

        newPlatform.GetComponent<DisablePlane>().SetCoinsBack();

        lastPosition = newPlatform.transform.position;
        GameManager.instance.canAppear = false;
        pathCount++;
    }
}
