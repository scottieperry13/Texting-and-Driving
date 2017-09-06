using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour {

	public float TimeForNewText = 10f;
	public int responseNum = 0; // Sets the current emoji button that must be clicked

	private float TimeSinceStart = 0;

	CanvasGroup cg;
	public bool entryTime = false;
	public Button r1;
	public Button r2;
	public Button r3;

	Button a1;
	Button a2;
	Button a3;
	Button a4;

	Score scoreObj;

	private static TextTimer instance = null;
	// Handling to stay alive forever

	void Awake() {
		cg = Canvas.FindObjectOfType<CanvasGroup> (); 
//		if (instance == null) {
//			instance = this;
//			GameObject.DontDestroyOnLoad (this.gameObject);
//		} else {
//			GameObject.Destroy (this.gameObject);
//		}
		r1 = GameObject.Find("responseOne").GetComponent<Button>();
		r2 = GameObject.Find ("responseTwo").GetComponent<Button> ();
		r3 = GameObject.Find ("responseThree").GetComponent<Button> ();

		a1 = GameObject.Find ("sunglasses").GetComponent<Button> ();
		a2 = GameObject.Find ("kiss").GetComponent<Button> ();
		a3 = GameObject.Find ("sad").GetComponent<Button> ();
		a4 = GameObject.Find ("angry").GetComponent<Button> ();
		scoreObj = GameObject.Find ("Score").GetComponent<Score> ();
		responseNum = 0;
		TimeSinceStart = 0;
		TimeForNewText = 5f;
	}

	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("Score").GetComponent<Score> ().gameOver) {
			GameObject.Find ("GameObject").GetComponent<TextTimer> ().enabled = false;
		} else {
			GameObject.Find ("GameObject").GetComponent<TextTimer> ().enabled = true;
		}

		// Count up the timer
		if (!entryTime) {
			TimeSinceStart += Time.deltaTime;
//			Debug.Log (TimeSinceStart.ToString () +
//			"/" + TimeForNewText.ToString ());
			if (TimeSinceStart > TimeForNewText) {
				TimeSinceStart = 0;
				TimeForNewText = Random.Range (10f, 15f);
				StartTexts ();
			}
		}

		// Reset
		if (responseNum == 3) {
			ResetText ();
		}
	}

	public void ResetText() {
		// Reset the response number
		responseNum = 0;

		// Hide the text bubble
		cg.alpha = 0f;
		cg.interactable = false;
		cg.blocksRaycasts = false;

		//Disable emoji buttons
		r1.interactable = false;
		r2.interactable = false;
		r3.interactable = false;
		a1.interactable = false;
		a2.interactable = false;
		a3.interactable = false;
		a4.interactable = false;

		// Get the timer going again
		entryTime = false;

		scoreObj.ApplyBonus(500);
		if (scoreObj.perfectRun) {
			scoreObj.IncreaseMulti ();
		} else {
			scoreObj.perfectRun = true; // Reset to allow a chance to regain multiplier
		}
	}


	void StartTexts() {
		entryTime = true;
		//Debug.ClearDeveloperConsole ();
		//Debug.Log ("New Text!!!");
		cg.alpha = 1f;
		cg.blocksRaycasts = true;
		cg.interactable = true;

		a1.interactable = true;
		a2.interactable = true;
		a3.interactable = true;
		a4.interactable = true;

		//Get three random numbers for the emojis to respond with
		int[] newEmojis = new int[] {Random.Range(0,4), Random.Range(0,4), Random.Range(0,4)};

		setEmojis (newEmojis [0], r1);
		setEmojis (newEmojis [1], r2);
		setEmojis (newEmojis [2], r3);
	}

	void setEmojis(int option, Button btn) {

		switch (option) {
		case 0:
			btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("sunglasses");
			break;
		case 1:
			btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("kiss");
			break;
		case 2:
			btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("sad");
			break;
		case 3:
			btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("angry");
			break;
		default:
			break;
		}
	}
}
