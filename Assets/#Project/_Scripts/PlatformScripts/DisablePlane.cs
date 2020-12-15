using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlane : MonoBehaviour {

    public CoinCollector[] coins;


    private void Start()
    {
        coins = GetComponentsInChildren<CoinCollector>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("helper"))
        {
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.SetActive(false);
            GameManager.instance.canAppear = true;
        }
    }

    public void SetCoinsBack()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].gameObject.SetActive(true);
        }
    }
}
