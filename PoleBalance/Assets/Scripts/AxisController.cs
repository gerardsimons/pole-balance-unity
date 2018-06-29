using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisController : MonoBehaviour {

    public Vector3 forceVector;

    private Rigidbody rBody;

    private const RigidbodyConstraints released = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    private const RigidbodyConstraints attached = released | RigidbodyConstraints.FreezePositionX;

    // Use this for initialization
    void Start () {
        rBody = gameObject.GetComponent<Rigidbody>();
        rBody.constraints = attached;
    }

    public void Move(int direction)
    {
        direction = Mathf.Clamp(direction, -1, 1);
        if(direction == 0)
        {
            rBody.constraints = attached;
        }
        else
        {
            string s = direction == -1 ? "LEFT" : "RIGHT";
            print("Moving axis in " + s + " direction");

            rBody.constraints = released;
            rBody.AddForce(forceVector * direction);
        }
    }

    void ManageKeys()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Left arrow pressed!");
            rBody.constraints = released;
            rBody.AddForce(forceVector);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Right arrow pressed!");
            rBody.constraints = released;
            rBody.AddForce(-forceVector);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.RightArrow))
        {
            rBody.constraints = attached;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //ManageKeys();
    }
}
