using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	public GameObject SceneManager;
	public GameObject FarBGObject;
	public GameObject MiddleBGObject;
	public GameObject CloseBGObject;
	GameSceneScript sceneScript;
	Vector3 FarBGStartPosition;
	Vector3 MiddleBGStartPosition;
	Vector3 CloseBGStartPosition;
	float farBGwidth;
	float middleBGwidth;
	float closeBGwidth;


	// Use this for initialization
	void Start ()
	{
		FarBGStartPosition = FarBGObject.transform.position;
		//MiddleBGStartPosition = MiddleBGObject.transform.position;
		CloseBGStartPosition = CloseBGObject.transform.position;
		sceneScript = SceneManager.GetComponent<GameSceneScript> ();
		farBGwidth = FarBGObject.GetComponent<SpriteRenderer> ().bounds.size.x * 2;
		//middleBGwidth = middleBGObject.GetComponent<Sprite> ().bounds.size.x;
		closeBGwidth = CloseBGObject.GetComponent<SpriteRenderer> ().bounds.size.x;
	}

	// Update is called once per frame
	void Update ()
	{
		float farPositionDelta = Mathf.Repeat (Time.time * sceneScript.playerSpeed, farBGwidth);
		float closePositionDelta = Mathf.Repeat (Time.time * sceneScript.playerSpeed, closeBGwidth);
		FarBGObject.transform.position = FarBGStartPosition + Vector3.left * farPositionDelta * 0.5f;
		//MiddleBGObject.transform.position = MiddleBGStartPosition + Vector3.left * positionDelta * 0.7f;
		CloseBGObject.transform.position = CloseBGStartPosition + Vector3.left * closePositionDelta;
	}
}
