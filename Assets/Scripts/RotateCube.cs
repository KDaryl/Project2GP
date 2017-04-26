using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

    float rotateSpeed = 75.0f;
    int rotateWay = 0; //thos number determines which way the cube will rotate

	// Use this for initialization
	void Start () {

        rotateWay = Random.Range(1, 4); //generates a number between 1 and 4
    }
	
	// Update is called once per frame
	void Update () {

        if(rotateWay == 1)
        {
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (rotateWay == 2)
        {
            transform.Rotate(Vector3.right * -rotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        if (rotateWay == 3)
        {
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        if (rotateWay == 4)
        {
            transform.Rotate(Vector3.right * -rotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
