using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnContact : MonoBehaviour {
	[SerializeField] UnityEngine.UI.Text gameOverText;
	[SerializeField] UnityEngine.UI.Text tapToContinueText;
	[SerializeField] GameObject hideOnGameOver;
	[SerializeField] GameObject finalExplosion;
	bool isGameOver;
	const float textFadeTime = 2.0f;
	const float delayBetweenExplosionAndText = 0.5f;

	void Start () {
		gameOverText.CrossFadeAlpha( 0.0f, 0.0f, false );
		tapToContinueText.CrossFadeAlpha( 0.0f, 0.0f, false );
	}

	void OnTriggerEnter () {
		StartCoroutine( GameOver() );
	}

	IEnumerator GameOver () {
		Time.timeScale = 0;
		if (hideOnGameOver != null) {
			hideOnGameOver.SetActive( false );
		}
		if (finalExplosion != null) {
			finalExplosion.SetActive( true );
			yield return new WaitForSecondsRealtime( delayBetweenExplosionAndText );
		}
		if (gameOverText != null) {
			gameOverText.CrossFadeAlpha( 1.0f, textFadeTime, true );
			yield return new WaitForSecondsRealtime( textFadeTime );
		}
		if (tapToContinueText != null) {
			tapToContinueText.CrossFadeAlpha( 1.0f, textFadeTime, true );
			isGameOver = true;
		}
	}

	void Update () {
		if (isGameOver && Input.GetButton( "Fire1" )) {
			Time.timeScale = 1.0f;
			UnityEngine.SceneManagement.SceneManager.LoadScene( 0 );
		}
	}
	
}
