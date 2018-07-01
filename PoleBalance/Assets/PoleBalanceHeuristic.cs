using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleBalanceHeuristic : MonoBehaviour, Decision {
    float[] Decision.Decide(List<float> state, List<Camera> observation, float reward, bool done, float[] memory)
    {
        return new float[]{Random.Range(-1, 1)};
    }

    float[] Decision.MakeMemory(List<float> state, List<Camera> observation, float reward, bool done, float[] memory)
    {
        return new float[] { };
    }
}
