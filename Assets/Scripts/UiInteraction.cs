using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class UiInteraction : MonoBehaviour {

    bool changeScene;
    bool startTimer;
    float timer;

	// Use this for initialization
	void Start () {
        changeScene = false;
        startTimer = false;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(startTimer)
        {
            timer += 1.0f / 60.0f;

            if(timer >= 2)
            {
                if(this.gameObject.name == "Start Text")
                    changeScene = true;
                else if (this.gameObject.name == "Exit Text")
                    Application.Quit();
                else
                {
                    SceneManager.UnloadSceneAsync(1);
                    SceneManager.LoadScene(1);
                }
                    
            }
        }

        if(changeScene)
        {
            changeScene = false;
            SceneManager.LoadScene(1);
            SceneManager.UnloadSceneAsync(0);
        }

    }

    public void PointerEnter()
    {
        print("Pointing at target!");
        startTimer = true;
        timer += 1.0f / 60.0f;
    }

    public void PointerExit()
    {
        if (timer >= 0.2f)
        {
            startTimer = false;
            timer = 0;
        }
    }
}
