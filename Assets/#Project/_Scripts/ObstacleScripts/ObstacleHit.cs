using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleHit : MonoBehaviour
{
    int finalScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerController>().gameObject.SetActive(false);
            finalScore = GameManager.instance.score;
            PlayerPrefs.SetInt("Score", finalScore);
            SceneManager.LoadScene(2);
        }

        if (other.CompareTag("car"))
        {
            other.GetComponent<CarController>().speed = 0f;
        }
    }
}
