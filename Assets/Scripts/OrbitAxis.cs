using UnityEngine;

public class OrbitAxis : MonoBehaviour
{
    private int orbitMode = -1;
    
    private static Vector3 GetRandomPerpendicularTo(Vector3 v)
    {
        var perpendicular = Vector3.zero;
        while (perpendicular == Vector3.zero)
        {
            var w = Random.onUnitSphere;
            perpendicular = Vector3.Cross(v, w );
        }
        return perpendicular;
    }

    public Vector3 GetOrbitAxis(Vector3 centreToOrbiter)
    {
       return orbitMode == 0
                ? Random.value > 0.5 ? Vector3.up : -Vector3.up // CW or CCW rotation 
                : GetRandomPerpendicularTo(centreToOrbiter); // random great circles
    }
    
    public void OrbitModeUpdated(int orbitMode)
    {
        this.orbitMode = orbitMode;
    }
        
}
