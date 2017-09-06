using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartNew() {
		gameObject.GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene (1, LoadSceneMode.Single);;
	}
}
