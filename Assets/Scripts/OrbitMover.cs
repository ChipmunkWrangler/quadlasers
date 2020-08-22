using UnityEngine;

public class OrbitMover : MonoBehaviour
{
    public float minOrbitSpeedAtBaseDistance;   // speed up as you get closer, but stop speeding up at base distance
    public float maxOrbitSpeedAtBaseDistance;
    [SerializeField] public float approachSpeedAtBaseDistance;  // slow down as you get closer
    [SerializeField] public float baseDistance;

    private Vector3 orbitCentre;
    private float orbitSpeedAtBaseDistance;
    private bool isOrbiting;
    private Vector3 orbitAxis;
    private void MoveTowards(Vector3 dir, float dist)
    {
        float speedMultiplier = dist / baseDistance;
        GetComponent<Rigidbody>().velocity = dir * approachSpeedAtBaseDistance * speedMultiplier;
    }

    private void OrbitAround(OrbitData orbitData)
    {
        orbitCentre = orbitData.Midpoint;
        orbitSpeedAtBaseDistance = Random.Range(minOrbitSpeedAtBaseDistance, maxOrbitSpeedAtBaseDistance);
        isOrbiting = true;
        orbitAxis = orbitData.Axis;
    }

    private Vector3 getVectorToCentre()
    {
        return orbitCentre - transform.position;
    }

    private void Update()
    {
        // TODO Try replacing this with gravity plus an initial momentum
        if (!isOrbiting) return;
        var toCentre = getVectorToCentre();
        var dist = toCentre.magnitude;
        var speedMultiplier = Mathf.Min(1.0f, baseDistance / dist);
        var angleToMove = orbitSpeedAtBaseDistance * speedMultiplier * Time.deltaTime;
        transform.RotateAround(orbitCentre, orbitAxis, angleToMove);
        MoveTowards(toCentre.normalized, dist);
    }

}
