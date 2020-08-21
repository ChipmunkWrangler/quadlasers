using System.Collections;
using AssemblyCSharp;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject[] hazards;
    [SerializeField] public float spawnDistance;
    [SerializeField] public int minPerWave, maxPerWave;
    [SerializeField] public float initialWaitInSeconds;
    [SerializeField] public float waveGapInSeconds;
    [SerializeField] public float spawnGapInSeconds;
    [SerializeField] public GameObject[] subscribers;

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

    private void SpawnAsteroid()
    {
        var spawnPosition = Random.onUnitSphere * spawnDistance;
        var hazardPrototype = hazards[Random.Range(0, hazards.Length)];
        var asteroid = (GameObject)Instantiate(hazardPrototype, spawnPosition, Quaternion.identity);
        asteroid.SendMessage("SetController", gameObject);
        asteroid.SendMessage("OrbitAround", Camera.main.transform);
    }

    private void ObjectDestroyed(GameObject objectDestroyed)
    {
        SharedLibrary.InformSubscribers(subscribers, "ObjectDestroyed", objectDestroyed);
    }
}
