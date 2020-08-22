using UnityEngine;

public class HorizontalCircles : OrbitData
{
    private readonly float minY, maxY;

    public HorizontalCircles(float spawnDistance, float minY, float maxY)
    {
        this.minY = minY;
        this.maxY = maxY;
        CalcData(spawnDistance);
    }

    protected override Vector3 GetUnitPosition()
    {
        var onUnitCircle = Random.insideUnitCircle.normalized;
        return new Vector3(onUnitCircle.x, Random.Range(minY, maxY), onUnitCircle.y);
    }


    protected override Vector3 GetOrbitAxis()
    {
        return Random.value > 0.5 ? Vector3.up : -Vector3.up; // CW or CCW rotation 
    }
}