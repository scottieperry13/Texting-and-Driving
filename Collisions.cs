using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Car") { 
			GameObject.Find("Left Headlight").GetComponent<AudioSource> ().Play ();
			GetComponent<Movement> ().enabled = false;
			other.gameObject.GetComponent<CarObstacleMovement>().enabled = false;
			GetComponent<GenerateObjects> ().enabled = false;
			GameObject.Find ("Score").GetComponent<Score> ().gameOver = true;
			GameObject.Find ("GameObject").GetComponent<TextTimer> ().ResetText ();
			StartCoroutine ("Death");
		}
		if (other.tag == "GasCan") {
			GetComponent<Movement> ().speed += 5f;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			//Destroy (other.gameObject);
		}
	}

	IEnumerator Death(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (2);
	}
}
