using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CarController : MonoBehaviour
{
    public float speed = 10f;

    public GameObject player;

    private float playerPos;
    private float carPos;

    int finalScore;



    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Vector3 move = Vector3.forward * speed * Time.deltaTime;

            this.transform.Translate(move);

            playerPos = player.transform.position.z;
            carPos = this.transform.position.z;

            if (playerPos > carPos + 10)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            this.speed = 0f;
        }

        if (other.CompareTag("Player"))
        {
            finalScore = GameManager.instance.score;
            PlayerPrefs.SetInt("Score", finalScore);

            SceneManager.LoadScene(2);
        }
    }
}
