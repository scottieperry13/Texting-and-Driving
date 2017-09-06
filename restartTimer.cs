using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartTimer : MonoBehaviour {
	CanvasGroup cg;
	GameObject mainObject;


	void Awake() {
		cg = Canvas.FindObjectOfType<CanvasGroup> ();
	}

	void Start() {
		mainObject = GameObject.Find ("GameObject");


	}
	// Use this for initialization
	public void OnPointerDown() {
		cg.alpha = 0f;
		cg.interactable = false;
		cg.blocksRaycasts = false;

		TextTimer textTimer = mainObject.GetComponent<TextTimer> ();
		textTimer.entryTime = false;

	}
}
