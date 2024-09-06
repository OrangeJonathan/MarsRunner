using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public enum RotationAxis { X, Y, Z };
    public RotationAxis rotationAxis = RotationAxis.Y;

    void Update()
    {
        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.Rotate(rotationSpeed, 0, 0, Space.World);
                break;
            case RotationAxis.Y:
                transform.Rotate(0, rotationSpeed, 0, Space.World);
                break;
            case RotationAxis.Z:
                transform.Rotate(0, 0, rotationSpeed, Space.World);
                break;
            default:
                transform.Rotate(rotationSpeed, 0, 0, Space.World);
                break;
        }
    }
}
