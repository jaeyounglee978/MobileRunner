using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{

	public float gravity;
	Vector3 velocity;
	public GameObject GameOverLayer;
	public GameObject SceneManager;
	GameSceneScript sceneManager;

	// Use this for initialization
	void Start ()
	{
		//velocity.y = gravity;
		sceneManager = SceneManager.GetComponent<GameSceneScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += velocity * Time.deltaTime;
		velocity += Vector3.down * gravity * Time.deltaTime;

		if (transform.position.y <= -2.3)
		{
			GameObject stamp = OverlapChecker ();

			if (stamp != null)
			{
				velocity = Vector3.up * stamp.GetComponent<EnemyScript> ().elastic;
				sceneManager.playerSpeed += 2.0f;
				sceneManager.UpdateScore (stamp.GetComponent<EnemyScript> ().score);
			}
			else
			{
				GameOverLayer.SetActive (true);	
			}
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			GameObject stamp = Stamping ();

			if (stamp != null)
			{
				Debug.Log ("Jump");
				velocity = Vector3.up * stamp.GetComponent<EnemyScript> ().elastic;
				sceneManager.playerSpeed += 1.0f;
				sceneManager.UpdateScore (stamp.GetComponent<EnemyScript> ().score);
			}
			else
			{
				GameOverLayer.SetActive (true);	
			}
		}
	}

	GameObject Stamping()
	{
		transform.position = new Vector3 (transform.position.x, -2.3f, transform.position.z);

		return OverlapChecker ();
	}

	GameObject OverlapChecker()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

		Debug.Log (colliders.Length);

		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject.tag == "Enemy")
				return colliders [i].gameObject;
		}

		return null;
	}
}
