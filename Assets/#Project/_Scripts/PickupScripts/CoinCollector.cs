using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour {

    ParticleController particleController;

    private string myTag;


    void Start()
    {
        particleController = FindObjectOfType<ParticleController>();
        myTag = this.gameObject.tag;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleController.transform.position = transform.position;
            particleController.PlayParticle();
            //EventManager.TriggerEvent("IncreaseScore");
            //EventManager.TriggerEvent("PlayParticle");
            AudioManager.instance.PlaySound("coin");
            gameObject.SetActive(false);
            GameManager.instance.IncreaseScore();
            UIManager.instance.CoinCollected(myTag, this.transform);
        }
    }
}
