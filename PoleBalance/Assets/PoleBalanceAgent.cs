using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Assertions;

public class PoleBalanceAgent : Agent {

    private AxisController axisController;

    private float optimialZRot = 0;

    public GameObject pendulum;

    public override List<float> CollectState()
    {
        List<float> state = new List<float>();

        return state;
    }

    private double calculateDifferenceBetweenAngles(double firstAngle, double secondAngle)
    {
        double difference = secondAngle - firstAngle;
        while (difference < -180) difference += 360;
        while (difference > 180) difference -= 360;

        return difference;
    }

    public override void AgentStep(float[] act)
    {
        print("AGENT STEP #" + stepCounter);
        int direction = (int)act[0];
        axisController.Move(direction);

        // Determine reward based on rotation of pendulum shaft
        float zRot = pendulum.transform.rotation.eulerAngles.z;
        Debug.Log("zRot = " + zRot);

        float zDiff = Mathf.Abs(Mathf.DeltaAngle(optimialZRot, zRot));
        Debug.Log("zDiff = " + zDiff);
        reward = 1 - zDiff  / 180f;
        print("Reward = " + reward);
    }

    public override void AgentReset()
    {
        print("POLE BALANCE AGENT RESET!");

        pendulum.transform.position = new Vector3(0, 0.3f, 0.27f);
        pendulum.transform.rotation = Quaternion.Euler(0, 0, 0);
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
