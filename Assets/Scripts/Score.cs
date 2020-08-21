﻿using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private int score;

	void ObjectDestroyed (GameObject gameObj) {
		if (gameObj.tag == "Enemy") {
			++score;
			GetComponent<Text> ().text = score.ToString();
		}
	}

}
