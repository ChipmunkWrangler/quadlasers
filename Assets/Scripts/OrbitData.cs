using UnityEngine;

public abstract class OrbitData
{
    public Vector3 Midpoint { get; private set; }
    public Vector3 Axis { get; private set; }
    public Vector3 SpawnPosition { get; private set; }

    protected void CalcData(float spawnDistance)
    {
        SpawnPosition = GetUnitPosition() * spawnDistance;
        Midpoint = Camera.main.transform.position;
        Axis = GetOrbitAxis();
    }

    protected abstract Vector3 GetUnitPosition();


    protected abstract Vector3 GetOrbitAxis();
}