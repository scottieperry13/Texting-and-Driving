﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart() {
		gameObject.GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}
}
