using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MLAgents;
using UnityEngine.Assertions;

public class PoleBalanceAgent : Agent
{

    private AxisController axisController;

    private float optimialZRot = 0;

    public GameObject pendulum;

	public override void CollectObservations()
	{
        AddVectorObs(pendulum.transform.rotation.eulerAngles.z / 360.0f);
        AddVectorObs(transform.position.x);
	}

	public override void AgentAction(float[] vectorAction, string textAction)
	{
        //print("AGENT STEP #" + stepCounter);
        int direction = (int)vectorAction[0];
        axisController.Move(direction);

        // Determine reward based on rotation of pendulum shaft
        float zRot = pendulum.transform.rotation.eulerAngles.z;
        Debug.Log("zRot = " + zRot);

        float zDiff = Mathf.Abs(Mathf.DeltaAngle(optimialZRot, zRot));
        Debug.Log("zDiff = " + zDiff);
        float reward = (1 - zDiff / 180f) * 2 - 1;
        AddReward(reward);

        if(Mathf.Abs(transform.position.x) > 1) {
            print("OUT OF BOUNDS");
            Done();
        }

        print("Reward = " + reward);
	}

    public override void AgentReset()
    {
        print("POLE BALANCE AGENT RESET!");

        pendulum.transform.position = new Vector3(0, 0.3f, 0.27f);
        pendulum.transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position = Vector3.zero;
    }

    public override void AgentOnDone()
    {

    }

    public override void InitializeAgent()
    {
        axisController = gameObject.GetComponent<AxisController>();
        Assert.IsNotNull(axisController);

    }
}
