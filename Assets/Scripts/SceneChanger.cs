using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

    bool sceneLoaded = false;
    public GameObject player;
    Transform playerT;

    // Use this for initialization
    void Start()
    {
        playerT = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //if ()
        //{
        //    SceneManager.LoadScene(1);
        //    SceneManager.UnloadSceneAsync(0);
        //    sceneLoaded = true;
        //}
    }
}
