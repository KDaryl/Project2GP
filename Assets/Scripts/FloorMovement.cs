using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour {

    public GameObject player;
    float moveSpeed = 7.5f; //the speed our floor moves at
    Vector3 startPos; //the position the floor begins in
    float timeGone = 0;

	// Use this for initialization
	void Start () {
        startPos = transform.position; //assings our initial position the current sarting position of the floor
        startPos.z = 120; //sets the initial z value to 120, so each floor will move back to this position
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerHandler>().showOption == false)
        {
            timeGone += Time.deltaTime;

            if (timeGone >= 2)
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

                if (transform.position.z <= -119.5)
                {
                    transform.position = startPos;
                }
            }
        }
	}
}
