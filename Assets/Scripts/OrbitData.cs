using UnityEngine;

public class OrbitData
{
    public OrbitData(Vector3 midpoint, Vector3 axis) 
    {
        Midpoint = midpoint;
        Axis = axis;
    }

    public Vector3 Midpoint;
    public Vector3 Axis;
}