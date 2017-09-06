using UnityEngine;
using System.Collections;

public class SpinningPowerup : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
		transform.Rotate (0,0,60*Time.deltaTime);
	}
}
