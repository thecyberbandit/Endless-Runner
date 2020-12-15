using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	
	public void PlayRunAnimation()
    {
        anim.SetTrigger("run");
    }

    public void PlayJumpAnimation()
    {
        anim.SetTrigger("jump");
    }

    public void PlayIdleAnimation()
    {
        anim.SetTrigger("idle");
    }
}
