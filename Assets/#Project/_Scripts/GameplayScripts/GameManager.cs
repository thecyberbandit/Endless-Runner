using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStarted;
    [HideInInspector]
    public bool canAppear;
    [HideInInspector]
    public bool instructionOn;
    [HideInInspector]
    public bool gameOver;
    [HideInInspector]
    public bool restart;
    public int score;

    int finalScore;

    public Text scoreText;
    public Text timerText;

    //public GameObject count3;
    //public GameObject count2;
    //public GameObject count1;
    //public GameObject countGO;

    private float timeLeft = 60f;

    public RadialProgressBar bar;


    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        EventManager.StartListening("IncreaseScore", IncreaseScore);
    }

    private void Start()
    {
        AudioManager.instance.StopSound("win");
        AudioManager.instance.StopSound("loose");

        AudioManager.instance.PlaySound("background");

        instructionOn = false;
    }

    public void StartGame()
    {
        //UIManager.instance.StopCountdown();
        

        gameStarted = true;
        canAppear = false;
        //startCountdown = false;
    }

    public void IncreaseScore()
    {
        score += 10;
        scoreText.text = ": " + score.ToString();
    }

    private void Update()
    {
        //if (startCountdown)
        //{
        //    UIManager.instance.StartCountdown();

        //    StartCoroutine(Countdown(4));
        //}

        if (gameStarted)
        {
            bar.amount += 1.66f * Time.deltaTime;
            float amountFillled = bar.amount / 99f;
            bar.imageBackground.fillAmount = amountFillled;

            int temp = (int)timeLeft;
            timerText.text = temp.ToString();

            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 0)
        {
            finalScore = GameManager.instance.score;
            PlayerPrefs.SetInt("Score", finalScore);

            SceneManager.LoadScene(1);
        }

        if (!instructionOn && !gameStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                UIManager.instance.OnPlayButtonClicked();
            }
        }
    }

    

    void OnDisable()
    {
        EventManager.StopListening("IncreaseScore", IncreaseScore);
    }
}
