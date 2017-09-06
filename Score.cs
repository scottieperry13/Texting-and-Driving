using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	int score;
	int multi;
	public bool perfectRun = true;
	public bool gameOver = false;
	public bool neverText = true;

	// Use this for initialization
	void Awake () {
		score = 0;
		multi = 1;
		gameOver = false;
		perfectRun = true;
		neverText = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			score += (1 * multi);
			GetComponent<Text> ().text = score.ToString ();
		}
	}

	public void ApplyBonus(int bonus) {
		score += bonus;
	}

	public void IncreaseMulti() {
		multi += 1;
	}

	public void ResetMulti() {
		multi = 1;
	}
}
