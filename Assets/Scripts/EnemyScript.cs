using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float elastic;
	public float moveSpeed;
	public int score;

	// Use this for initialization
	void Start ()
	{
		score = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	}
}
