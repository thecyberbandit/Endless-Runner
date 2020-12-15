using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.StopSound("background");
        AudioManager.instance.PlaySound("win");

        StartCoroutine(PlayAgain());
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(5.3f);
        AudioManager.instance.PlaySound("background");
    }
}
