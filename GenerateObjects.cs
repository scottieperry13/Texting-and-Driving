using UnityEngine;
using System.Collections;

public class GenerateObjects : MonoBehaviour {
	private int spawnRate;
	private int updates = 0;

	void Awake () {
		spawnRate = 500;
	}

	void Update () {
		int lane = 0;
		int rand = (int)(Random.value * spawnRate);
		int randLane = (int)(Random.value * 3);
		if (randLane == 0)
			lane = -1;
		if (randLane == 1)
			lane = 0;
		if (randLane == 2)
			lane = 1;

		if (rand == 10) {
			GameObject jeep = Instantiate (GameObject.Find ("jeep"), new Vector3 (lane * 11, transform.position.y, transform.position.z + GetComponent<Movement>().speed * 2), transform.rotation) as GameObject;
			jeep.GetComponent<CarObstacleMovement> ().speed = GetComponent<Movement> ().speed - 10;
		}
		if (rand == 20) {
			Instantiate (GameObject.Find ("Gas Tank"), new Vector3 (lane * 11, transform.position.y, transform.position.z + GetComponent<Movement>().speed), GameObject.Find ("Gas Tank").transform.rotation);
		}
			
		if (updates == 10) {
			updates = 0;

			if (spawnRate > 21) {
				spawnRate--;
			}
		} else {
			updates++;
		}
	}
}
