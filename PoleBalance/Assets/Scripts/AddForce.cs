using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public Vector3 torqueForce;
    public Vector3 force;

    public float intervalSeconds;



	// Use this for initialization
	void Start () {
        InvokeRepeating("ApplyForce", 1, intervalSeconds);
	}

    void ApplyForce()
    {
        print("BOOM");

        gameObject.GetComponent<Rigidbody>().AddForce(force);
        gameObject.GetComponent<Rigidbody>().AddTorque(torqueForce);
    }
	
	// Update is called once per frame
	void Update () {
       
    }


}
