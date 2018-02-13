using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float elastic;
	public float moveSpeed;
	public int score;
    public GameObject SceneManager;
    GameSceneScript sceneScript;

	// Use this for initialization
	void Start ()
	{
        SceneManager = GameObject.Find("SceneManager");
        sceneScript = SceneManager.GetComponent<GameSceneScript>();
		score = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (sceneScript.isPlaying)
    		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	}
}
