using UnityEngine;
using UnityEngine.Assertions;

public class OrbitData
{
    public Vector3 Midpoint { get; }
    public Vector3 Axis { get; }
    public Vector3 SpawnPosition { get; }

    // mode 0: horizontal circles, y = 0
    // mode 1: horizontal circles, y is limited to +/- 45 degrees
    // mode 2: random great circles
    // mode 3: as mode 0, but backstop
    // mode 4: as mode 1, but backstop
    // mode 5: as mode 2, but backstop
    // mode 3: TODO vertical circles
    public OrbitData(float spawnDistance, int mode)
    {
        SpawnPosition = GetSpawnPosition(spawnDistance, mode);
        Midpoint = Camera.main.transform.position;
        Axis = GetOrbitAxis(Midpoint - SpawnPosition, mode);
    }

    private static Vector3 GetHorizontalCirclePosition(float y)
    {
        var onUnitCircle = Random.insideUnitCircle.normalized;
        return new Vector3(onUnitCircle.x, y, onUnitCircle.y);
    }

    private static Vector3 GetSpawnPosition(float spawnDistance, int mode)
    {
        var unitPos = Vector3.zero;
        switch (mode)
        {
            case 0:
            case 3:
                unitPos = GetHorizontalCirclePosition(0);
                break;
            case 1:
            case 4:
                unitPos = GetHorizontalCirclePosition(Random.Range(-1f, 1f));
                break;
            case 2:
            case 5:
                unitPos = Random.onUnitSphere;
                break;
            default:
                Assert.IsTrue(false, $"Unknown orbit mode {mode}!");
                break;
        }

        return unitPos * spawnDistance;
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

    private static Vector3 GetOrbitAxis(Vector3 centreToOrbiter, int mode)
    {
        return mode == 0 || mode == 1
            ? Random.value > 0.5 ? Vector3.up : -Vector3.up // CW or CCW rotation 
            : GetRandomPerpendicularTo(centreToOrbiter); // random great circles
    }

}