using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public float spawnZ;
	public float minSpawnX, maxSpawnX;
	public int minPerWave, maxPerWave;
	public float initialWaitInSeconds;
	public float waveGapInSeconds;
	public float spawnGapInSeconds;
	public GameObject[] subscribers;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		StartCoroutine( SpawnWaves() );
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds( initialWaitInSeconds );
		while (true) {
			yield return StartCoroutine( SpawnWave( Random.Range( minPerWave, maxPerWave ) ) );
			yield return new WaitForSeconds( waveGapInSeconds );
		}
	}

	IEnumerator SpawnWave (int numToSpawn) {
		for (int i = 0; i < numToSpawn; ++i) {
			SpawnAsteroid();
			yield return new WaitForSeconds( spawnGapInSeconds );
		}
	}

	void SpawnAsteroid () {
		Vector3 spawnPosition = new Vector3( Random.Range( minSpawnX, maxSpawnX ), 0, spawnZ );
		GameObject hazardPrototype = hazards[ Random.Range( 0, hazards.Length ) ];
		GameObject asteroid = (GameObject)Instantiate( hazardPrototype, spawnPosition, Quaternion.identity );
		asteroid.SendMessage( "SetController", gameObject );
	}

	void ObjectDestroyed (GameObject objectDestroyed) {
		AssemblyCSharp.SharedLibrary.InformSubscribers( subscribers, "ObjectDestroyed", objectDestroyed );
	}
}
