using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    ParticleSystem coinParticle;

    void OnEnable()
    {
        EventManager.StartListening("PlayParticle", PlayParticle);    
    }

    void OnDisable()
    {
        EventManager.StopListening("PlayParticle", PlayParticle);
    }


    void Start ()
    {
        coinParticle = GetComponent<ParticleSystem>();	
	}
	
	
    public void PlayParticle()
    {
        if (!coinParticle.isPlaying)
        {
            coinParticle.Play();
        }

        else
        {
            coinParticle.Stop();
            coinParticle.Play();
        }
    }
}
