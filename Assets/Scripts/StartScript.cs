using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject SceneManager;
	GameSceneScript sceneManager;
	public GameObject Player;
	public GameObject Floor;
	public GameObject StartStage;
	public GameObject Camera;
	bool ready;
	bool coroutineRunning;
	float moveSpeed = 4;

	// Use this for initialization
	void Start ()
	{
		sceneManager = SceneManager.GetComponent<GameSceneScript> ();
		ready = false;
		coroutineRunning = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!ready && !coroutineRunning)
		{
			StartCoroutine (StartAction ());
		}
		if (ready)
		{
			sceneManager.isPlaying = true;
			ready = false;
		}
	}

	IEnumerator StartAction()
	{
		coroutineRunning = true;
		Debug.Log ("Start");
		while (Player.transform.position.x <= 0)
		{
			Player.transform.Translate (moveSpeed * Time.deltaTime, 0, 0);
			StartStage.transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			Floor.transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			yield return new WaitForEndOfFrame();
		}

		StartCoroutine(Camera.GetComponent<CameraScript> ().CameraStart());

		while(StartStage.transform.position.x >= -5f)
		{
			StartStage.transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			Floor.transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			yield return new WaitForEndOfFrame ();
		}
		Debug.Log ("platform move" + StartStage.transform.position);

		Debug.Log ("ready");
		Player.GetComponent<CharacterScript> ().velocity += Vector3.up * 2;


		while (StartStage.transform.position.x >= -11f)
		{
			StartStage.transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			Floor.transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			yield return new WaitForEndOfFrame ();
		}
		Debug.Log ("platform move" + StartStage.transform.position);
		Debug.Log ("platform move" + Floor.transform.position);

		StartStage.SetActive (false);
		sceneManager.SetFloorPosition ();

		ready = true;
		yield return null;
	}
}
