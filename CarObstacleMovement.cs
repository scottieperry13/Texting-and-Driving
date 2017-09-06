using UnityEngine;
using System.Collections;

public class CarObstacleMovement : MonoBehaviour {
	public float speed;
	private int lane;
	private int moveLanes;
	private bool isRunning = false;
	private Vector3 newPosition;

	void Awake () {
		newPosition = transform.position;
		moveLanes = (int)(Random.value * 100);
		lane = (int) (transform.position.x / 11);
	}

	void Update () {
		if (isRunning == false)
			moveLanes = (int)(Random.value * 100);
		if (moveLanes == 15 && isRunning == false) {
			isRunning = true;
			moveLanes++;
			StartCoroutine ("laneSwitch");
		}
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		transform.position = Vector3.MoveTowards (transform.position, new Vector3 (newPosition.x, transform.position.y, transform.position.z), 30 * Time.deltaTime);
	}

	IEnumerator laneSwitch(){
		
		if (lane == 1) {
			transform.FindChild ("Left Blinker").GetComponent<Light> ().enabled = true;
			yield return new WaitForSeconds (2);
			transform.FindChild ("Left Blinker").GetComponent<Light> ().enabled = false;
			newPosition = transform.position;
			newPosition.x = 0;
			lane = 0;
		} else if (lane == -1) {
			transform.FindChild ("Right Blinker").GetComponent<Light> ().enabled = true;
			yield return new WaitForSeconds (2);
			transform.FindChild ("Right Blinker").GetComponent<Light> ().enabled = false;
			newPosition = transform.position;
			newPosition.x = 0;
			lane = 0;
		} else if (lane == 0) {
			if (Random.value < .5) {
				transform.FindChild ("Right Blinker").GetComponent<Light> ().enabled = true;
				yield return new WaitForSeconds (2);
				transform.FindChild ("Right Blinker").GetComponent<Light> ().enabled = false;
				newPosition = transform.position;
				newPosition.x = 11;
				lane = 1;
			} else {
				transform.FindChild ("Left Blinker").GetComponent<Light> ().enabled = true;
				yield return new WaitForSeconds (2);
				transform.FindChild ("Left Blinker").GetComponent<Light> ().enabled = false;
				newPosition = transform.position;
				newPosition.x = -11;
				lane = -1;
			}
		}
		isRunning = false;
	}
}
