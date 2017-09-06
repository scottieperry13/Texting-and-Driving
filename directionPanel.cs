using UnityEngine;
using System.Collections;

public class directionPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void Awake() {
		gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void Show() {
		gameObject.SetActive (true);
	}
}
