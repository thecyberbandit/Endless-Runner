using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loose : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.StopSound("background");
        AudioManager.instance.PlaySound("loose");

        StartCoroutine(PlayAgain());
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(1.3f);
        AudioManager.instance.PlaySound("background");
    }
}
