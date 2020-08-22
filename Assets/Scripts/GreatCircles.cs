using UnityEngine;

public class GreatCircles : OrbitData
{
    public GreatCircles(float spawnDistance) 
    {
        CalcData(spawnDistance);
    }

    protected override Vector3 GetUnitPosition()
    {
        return Random.onUnitSphere;
    }


    protected override Vector3 GetOrbitAxis()
    {
        var centreToOrbiter = Midpoint - SpawnPosition;
        return GetRandomPerpendicularTo(centreToOrbiter);
    }

    private static Vector3 GetRandomPerpendicularTo(Vector3 v)
    {
        var perpendicular = Vector3.zero;
        while (perpendicular == Vector3.zero)
        {
            var w = Random.onUnitSphere;
            perpendicular = Vector3.Cross(v, w);
        }

        return perpendicular;
    }
}