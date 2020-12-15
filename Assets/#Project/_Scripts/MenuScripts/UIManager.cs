using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameOverPanel;
    public GameObject countdown;
    public GameObject countdown2;
    public GameObject instructionPanel;
    public GameObject[] collectionImagesleft;
    public GameObject[] collectionImagesright;

    public static UIManager instance;

    Text countdownText;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        countdownText = countdown.GetComponentInChildren<Text>();
    }

    public void OnPlayButtonClicked()
    {
        GameManager.instance.instructionOn = true;

        menuPanel.SetActive(false);
        instructionPanel.SetActive(true);

        StartCoroutine(Countdown());
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        instructionPanel.SetActive(false);
        //GameManager.instance.startCountdown = true;

        AudioManager.instance.PlaySound("countdown");

        StartCoroutine(CountdownTimer());
    }

    public void CoinCollected(string tag, Transform coinPos)
    {
        if (coinPos.position.x < 0)
        {
            collectionImagesleft[0].SetActive(false);
            collectionImagesleft[1].SetActive(false);
            collectionImagesleft[2].SetActive(false);
            collectionImagesleft[3].SetActive(false);
            collectionImagesleft[4].SetActive(false);
            collectionImagesright[0].SetActive(false);
            collectionImagesright[1].SetActive(false);
            collectionImagesright[2].SetActive(false);
            collectionImagesright[3].SetActive(false);
            collectionImagesright[4].SetActive(false);

            if (tag == "GP Points")
            {
                collectionImagesleft[0].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[0]));
            }

            else if (tag == "Emergency Bonus")
            {
                collectionImagesleft[1].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[1]));
            }

            else if (tag == "Flexiplan")
            {
                collectionImagesleft[2].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[2]));
            }

            else if (tag == "Online Recharge")
            {
                collectionImagesleft[3].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[3]));
            }

            else if (tag == "Data Pack Bonus")
            {
                collectionImagesleft[4].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[4]));
            }
        }

        else if (coinPos.position.x > 0)
        {
            collectionImagesright[0].SetActive(false);
            collectionImagesright[1].SetActive(false);
            collectionImagesright[2].SetActive(false);
            collectionImagesright[3].SetActive(false);
            collectionImagesright[4].SetActive(false);
            collectionImagesleft[0].SetActive(false);
            collectionImagesleft[1].SetActive(false);
            collectionImagesleft[2].SetActive(false);
            collectionImagesleft[3].SetActive(false);
            collectionImagesleft[4].SetActive(false);

            if (tag == "GP Points")
            {
                collectionImagesright[0].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[0]));
            }

            else if (tag == "Emergency Bonus")
            {
                collectionImagesright[1].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[1]));
            }

            else if (tag == "Flexiplan")
            {
                collectionImagesright[2].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[2]));
            }

            else if (tag == "Online Recharge")
            {
                collectionImagesright[3].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[3]));
            }

            else if (tag == "Data Pack Bonus")
            {
                collectionImagesright[4].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[4]));
            }
        }

        else if (coinPos.position.x == 0)
        {
            collectionImagesright[0].SetActive(false);
            collectionImagesright[1].SetActive(false);
            collectionImagesright[2].SetActive(false);
            collectionImagesright[3].SetActive(false);
            collectionImagesright[4].SetActive(false);
            collectionImagesleft[0].SetActive(false);
            collectionImagesleft[1].SetActive(false);
            collectionImagesleft[2].SetActive(false);
            collectionImagesleft[3].SetActive(false);
            collectionImagesleft[4].SetActive(false);

            if (tag == "GP Points")
            {
                collectionImagesright[0].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[0]));
            }

            else if (tag == "Emergency Bonus")
            {
                collectionImagesleft[1].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[1]));
            }

            else if (tag == "Flexiplan")
            {
                collectionImagesright[2].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[2]));
            }

            else if (tag == "Online Recharge")
            {
                collectionImagesleft[3].SetActive(true);
                StartCoroutine(Collected(collectionImagesleft[3]));
            }

            else if (tag == "Data Pack Bonus")
            {
                collectionImagesright[4].SetActive(true);
                StartCoroutine(Collected(collectionImagesright[4]));
            }
        }
    }

    IEnumerator Collected(GameObject go)
    {
        yield return new WaitForSeconds(2f);
        go.SetActive(false);
    }

    IEnumerator CountdownTimer()
    {
        countdownText.text = "3";
        countdown.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);

        countdownText.text = "2";
        countdown.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);

        countdownText.text = "1";
        countdown.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);

        countdown2.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown2.SetActive(false);

        GameManager.instance.StartGame();
    }
}
