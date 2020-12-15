using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObstacle : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
