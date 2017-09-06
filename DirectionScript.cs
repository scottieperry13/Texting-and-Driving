using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DirectionScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowDirections() {
		GameObject.Find ("DirectionPanel").SetActive(true);
	}
}