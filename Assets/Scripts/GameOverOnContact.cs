using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnContact : MonoBehaviour {
	[SerializeField] UnityEngine.UI.Text gameOverText;
	[SerializeField] UnityEngine.UI.Text tapToContinueText;

	void Start () {
		gameOverText.CrossFadeAlpha( 0.0f, 0.0f, false );
		tapToContinueText.CrossFadeAlpha( 0.0f, 0.0f, false );
	}

	void OnTriggerEnter () {
		GameOver();		
	}

	void GameOver () {
		if (gameOverText != null) {
			gameOverText.CrossFadeAlpha( 1.0f, 2.0f, true );
		}
		if (tapToContinueText != null) {
			tapToContinueText.CrossFadeAlpha( 1.0f, 5.0f, true );
		}
		Time.timeScale = 0;
		Debug.Log( "Game over" );

	}
	
}
