using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	
	public float speed=1f;
	private float lane;


	void Awake() {
		Application.targetFrameRate = 60;
		StartCoroutine ("Instructions");
		lane = 0;
		GameObject.Find ("Score").GetComponent<Score> ().gameOver = false;
	}

	void Start () {
		
	}

	void Update() 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		if (speed <= 150f)
			//Debug.Log ("" + speed);
			speed += .01f;

		if(Input.GetKeyDown(KeyCode.A)){
			if (lane > -1)
				lane--;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			if (lane < 1)
				lane++;
		}
		Vector3 newPosition = transform.position;
		newPosition.x = lane * 11;
		transform.position = Vector3.MoveTowards (transform.position, new Vector3 (newPosition.x, transform.position.y, transform.position.z), 30 * Time.deltaTime);
		transform.Rotate (Vector3.up, 0.0f);

		GameObject.Find ("Speedometer").GetComponentInChildren<Text>().text = ((int)speed).ToString() + " mph";
	
	}

	IEnumerator Instructions() {
		yield return new WaitForSeconds (5);
		GameObject.Find ("Instructions").GetComponent<Text> ().text = "";
	}
}
