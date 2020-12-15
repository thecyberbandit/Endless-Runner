using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    public Text scoreText;

    int finalScore;


    private void Start()
    {
        finalScore = PlayerPrefs.GetInt("Score");

        scoreText.text = ": " + finalScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
