using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    bool scaleDown = false; //bool to hold wheter to scale down our life icon or not

    int lives = 3; //the amount of lives the player starts off with

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    bool gameOver = false;
    public bool showOption = false;
    float timeSinceEnd = 0;

    GameObject previousLife;

    Vector3 finalScale = new Vector3(0, 0, 0);
    Vector3 scaleSpeed = new Vector3(0.025f, 0.025f, 0.025f);

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {

        //If the game is over
        if (gameOver && showOption == false)
        {
            timeSinceEnd += 1.0f /60.0f;

            if (timeSinceEnd >= 1.5)
            {
                showOption = true;
            }
        }
        else
        {

            //Scaling down our life icons whenever we collide with a cube
            if (scaleDown)
            {
                if (previousLife.GetComponent<Transform>().localScale.x > 0)
                {
                    if (previousLife.GetComponent<Transform>().localScale.x < scaleSpeed.x)
                    {
                        previousLife.GetComponent<Transform>().localScale = finalScale;
                        scaleDown = false;
                    }
                    else
                        previousLife.GetComponent<Transform>().localScale -= scaleSpeed;

                    if (previousLife.GetComponent<Transform>().localScale.x <= 0)
                    {
                        previousLife.GetComponent<Transform>().localScale = finalScale;
                        scaleDown = false;
                    }
                }
            }

            //Slowing down the game 
            if (lives == 0)
            {

                if (Time.timeScale > 0)
                {
                    if (Time.timeScale <= 0.003f)
                    {
                        Time.timeScale = 0;
                        gameOver = true;
                    }
                    else
                        Time.timeScale -= 0.003f;
                }

            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (lives > 0)
        {
            lives--;
            scaleDown = true;

            if(lives == 2)
                previousLife = life3;
            if (lives == 1)
                previousLife = life2;
            if (lives == 0)
                previousLife = life1;
        }
    }
}
