using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundry : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float internalLeftSide;
    public float internalRightSide;

    void Update()
    {
        internalLeftSide = leftSide;
        internalRightSide = rightSide;

    }
}
