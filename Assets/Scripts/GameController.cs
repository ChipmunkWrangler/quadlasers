using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] hazards;
    [SerializeField] float spawnDistance;
    [SerializeField] int minPerWave, maxPerWave;
    [SerializeField] float initialWaitInSeconds;
    [SerializeField] float waveGapInSeconds;
    [SerializeField] float spawnGapInSeconds;
    [SerializeField] GameObject[] subscribers;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialWaitInSeconds);
        while (true)
        {
            yield return StartCoroutine(SpawnWave(Random.Range(minPerWave, maxPerWave)));
            yield return new WaitForSeconds(waveGapInSeconds);
        }
    }

    IEnumerator SpawnWave(int numToSpawn)
    {
        for (int i = 0; i < numToSpawn; ++i)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(spawnGapInSeconds);
        }
    }

    void SpawnAsteroid()
    {
        var spawnPosition = Random.onUnitSphere * spawnDistance;
        var hazardPrototype = hazards[Random.Range(0, hazards.Length)];
        var asteroid = (GameObject)Instantiate(hazardPrototype, spawnPosition, Quaternion.identity);
        asteroid.SendMessage("SetController", gameObject);
        asteroid.SendMessage("OrbitAround", Camera.main.transform);
    }

    void ObjectDestroyed(GameObject objectDestroyed)
    {
        AssemblyCSharp.SharedLibrary.InformSubscribers(subscribers, "ObjectDestroyed", objectDestroyed);
    }
}
