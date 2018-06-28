using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceFromInput : MonoBehaviour {

    public Vector3 forceVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Left arrow pressed!");
            gameObject.GetComponent<Rigidbody>().AddForce(forceVector);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Right arrow pressed!");
            gameObject.GetComponent<Rigidbody>().AddForce(-forceVector);
        }
    }
}
