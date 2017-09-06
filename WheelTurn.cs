using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RectTransform rectTransform = GetComponent<RectTransform> ();


		//TODO: Implement rotation limits
		if (Input.GetKey (KeyCode.A)) {
			rectTransform.Rotate ( Vector3.forward * 45 * Time.deltaTime );
		}

		if (Input.GetKey (KeyCode.D)) {
			rectTransform.Rotate (Vector3.forward * -45 * Time.deltaTime);
		}
	}
}
