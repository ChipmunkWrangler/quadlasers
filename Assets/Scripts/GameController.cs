using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject[] hazards;
    [SerializeField] public float spawnDistance;
    [SerializeField] public int minPerWave, maxPerWave;
    [SerializeField] public float initialWaitInSeconds;
    [SerializeField] public float waveGapInSeconds;
    [SerializeField] public float spawnGapInSeconds;
    [SerializeField] public GameObject backstop;
    [SerializeField] public GameObject[] subscribers;

    [SerializeField] public float
        minY = -0.5f, maxY = 0.5f; // fraction of spawnDistance for modes that limit y angle. 1 => 45° 0.5 => 22.5°

    private int orbitMode = -1;

    // Use this for initialization
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialWaitInSeconds);
        while (true)
        {
            yield return StartCoroutine(SpawnWave(Random.Range(minPerWave, maxPerWave)));
            yield return new WaitForSeconds(waveGapInSeconds);
        }
    }

    private IEnumerator SpawnWave(int numToSpawn)
    {
        for (int i = 0; i < numToSpawn; ++i)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(spawnGapInSeconds);
        }
    }

    private static OrbitData CalculateOrbitData(float spawnDistance, int orbitMode, float minY, float maxY)
    {
        // mode 3: TODO vertical circles around y = 0
        // mode : TODO vertical circles around y = up to minY/maxY 
        // mode: like 1 or 2 but limited vertical mobility
        // mode: like 0 but turret is fixed at y=0 (like long ago)
        switch (orbitMode)
        {
            case 0: // horizontal circles, y = 0
            case 3: // as mode 0, but backstop
                return new HorizontalCircles(spawnDistance, 0, 0);
            case 1: // horizontal circles, y is limited to +/- 22.5 degrees
            case 4: // as mode 1, but backstop
                return new HorizontalCircles(spawnDistance, minY, maxY);
            case 2: // random great circles
            case 5: // as mode 2, but backstop
                return new GreatCircles(spawnDistance);
            default:
                Assert.IsTrue(false, $"Unknown orbit mode {orbitMode}");
                return new HorizontalCircles(spawnDistance, 0, 0);
        }
    }

    public void SpawnAsteroid()
    {
        var orbitData = CalculateOrbitData(spawnDistance, orbitMode, minY, maxY);
        var hazardPrototype = hazards[Random.Range(0, hazards.Length)];
        var asteroid = Instantiate(hazardPrototype, orbitData.SpawnPosition, Quaternion.identity);
        asteroid.SendMessage("SetController", gameObject);
        asteroid.SendMessage("OrbitAround", orbitData);
#if !UNITY_EDITOR
        var trailRenderer = asteroid.GetComponentInChildren<TrailRenderer>();
        if (trailRenderer)
            trailRenderer.enabled = false;
#endif
    }

    private void ObjectDestroyed(GameObject objectDestroyed)
    {
        SharedLibrary.InformSubscribers(subscribers, "ObjectDestroyed", objectDestroyed);
    }

    public void OrbitModeUpdated(int orbitMode)
    {
        this.orbitMode = orbitMode;
        backstop.SetActive(orbitMode > 2);
    }
}