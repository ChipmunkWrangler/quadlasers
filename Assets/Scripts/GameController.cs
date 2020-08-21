using System.Collections;
using AssemblyCSharp;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] hazards;
    [SerializeField] private float spawnDistance;
    [SerializeField] private int minPerWave, maxPerWave;
    [SerializeField] private float initialWaitInSeconds;
    [SerializeField] private float waveGapInSeconds;
    [SerializeField] private float spawnGapInSeconds;
    [SerializeField] private GameObject[] subscribers;

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
