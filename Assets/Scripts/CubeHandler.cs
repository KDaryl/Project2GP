using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour {

    public Transform childT; //the child transform assoiated with this object
    public GameObject player;
    float moveSpeed = 7.5f;
    float slideSpeed = 5.0f;
    float timeGone = 0; //holds the time gone since the last update

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        childT = this.gameObject.transform.GetChild(0);
        childT.localScale = new Vector3(0, 0, 0);
        startingPos = transform.position;
        startingPos.z = 55;
    }

    // Update is called once per frame
    void Update() {

        if (player.GetComponent<PlayerHandler>().showOption)
        {
            if(childT.localScale.x > 0)
            {
                childT.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
        else
        {
            timeGone += Time.deltaTime;

            if (childT.localScale.x < 1)
            {
                childT.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }

            if (timeGone >= 2)
            {

                //Get the players transform values and assign them to a variable
                var playerT = player.GetComponent<Transform>();

                //If the player is leaning/tilting left, move our cube to the right
                if (playerT.eulerAngles.z >= 5 && playerT.eulerAngles.z <= 85)
                {
                    transform.Translate(Vector3.right * slideSpeed * Time.deltaTime);
                }

                //If the player is leaning/tilting right, move our cube to the left
                if (playerT.eulerAngles.z <= 355 && playerT.eulerAngles.z >= 275)
                {
                    transform.Translate(Vector3.left * slideSpeed * Time.deltaTime);
                }

                //Move the cube towards the player
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);


                //checking if our cube has gone past the player
                if (transform.position.z <= 0)
                {
                    transform.position = startingPos;
                    childT.localScale = new Vector3(0, 0, 0);
                }
            }
        }
	}

    //if the cube collides with another object that has a collider/rigidbody
    private void OnCollisionEnter(Collision collision)
    {
        transform.position -= new Vector3(0,25,0);
    }
}
