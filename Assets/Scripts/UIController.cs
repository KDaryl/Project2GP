using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject player;
    public bool countScore = false;// holds a bool on wheter we start counting the players score or not
    public bool isGameOver = false;
    float score = 0;
    float timeGone = 0;
    float timer = 0;
    public GameObject scoreObj;
    public GameObject timeObject;
    public GameObject restartObj;
    public GameObject exitObj;
    Text scoreText;
    Text timeText;

    Vector3 scaleVect = new Vector3(0.01f, 0.01f, 0.01f);
    Vector3 finalScale = new Vector3(1, 1, 1);
    Vector3 initialScale = new Vector3(0,0,0);
    bool uiIsScaled = false;

    int minutes = 0;
    int seconds = 0;
    float scoreTimer = 0;

    // Use this for initialization
    void Start()
    {
        //scaling down our ui objects
        scoreObj.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        timeObject.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        restartObj.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        exitObj.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);

        scoreText = scoreObj.GetComponent<Text>();
        scoreText.text = "SCORE: 0";

        timeText = timeObject.GetComponent<Text>();
        timeText.text = "TIME: 0m 0s";
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is not over
        if (player.GetComponent<PlayerHandler>().showOption == false)
        {
            if (uiIsScaled == false)
            {
                scoreObj.GetComponent<Transform>().localScale += scaleVect;
                timeObject.GetComponent<Transform>().localScale += scaleVect;

                if (scoreObj.GetComponent<Transform>().localScale.x >= 1)
                {
                    scoreObj.GetComponent<Transform>().localScale = finalScale;
                    timeObject.GetComponent<Transform>().localScale = finalScale;

                    uiIsScaled = true;
                }

            }


            if (countScore == false)
            {
                timeGone += Time.deltaTime;
                if (timeGone >= 2)
                {
                    countScore = true;
                    timeGone = 0;
                }
            }

            if (countScore)
            {
                getTimer();
                getScore();
            }
        }

        else
        {
            if(scoreText.GetComponent<Transform>().localScale.x > 0)
                scaleDownUI();
            if (scoreText.GetComponent<Transform>().localScale.x < 0.5)
                scaleUpEndText();
        }
    }
    void scaleUpEndText()
    {
        if (restartObj.GetComponent<Transform>().localScale.x < 1)
        {
            restartObj.GetComponent<Transform>().localScale += scaleVect;
            exitObj.GetComponent<Transform>().localScale += scaleVect;
        }
        if (restartObj.GetComponent<Transform>().localScale.x >= 1)
        {
            Time.timeScale = 1;
        }
    }

    void scaleDownUI()
    {
        if(scoreText.GetComponent<Transform>().localScale.x < scaleVect.x)
        {
            scoreText.GetComponent<Transform>().localScale = initialScale;
            timeText.GetComponent<Transform>().localScale = initialScale;
        }
        scoreText.GetComponent<Transform>().localScale -= scaleVect;
        timeText.GetComponent<Transform>().localScale -= scaleVect;
    }

    void getTimer()
    {
        timer += Time.deltaTime; //adds the timegone to our timer variable
        timeGone += Time.deltaTime; //adds the time gone to our timegone variable

        //calculating our timer
        if (timeGone >= 1)
        {
            timeGone = 0;
            seconds++;

            if (seconds >= 60)
            {
                seconds = 0; //reset our seconds
                minutes++;

                if (minutes >= 60)
                {
                    minutes = 0; //reset our minutes
                }
            }
        }

        timeText.text = "TIME: " + (int)minutes + "m " + (int)seconds + "s";
    }

    //gets the score of the user
    void getScore()
    {
        score += 0.15f * Time.timeScale;

        scoreText.text = "SCORE: " + (int)score;
    }
}
