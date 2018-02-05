using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneScript : MonoBehaviour
{
	public GameObject PauseMenu;
	public GameObject Enemy;
	public GameObject Floor;
	public GameObject Score;
	int currentScore;
	float responeTime;
	public float playerSpeed;
	Vector3 startPosition;
	Queue<GameObject> EnemyQueue;

	// Use this for initialization
	void Start ()
	{
		PauseMenu.SetActive(false);
		responeTime = 1.0f;
		playerSpeed = 5.0f;
		startPosition = Floor.transform.position;
		currentScore = 0;
		Score.GetComponent<Text>().text = currentScore.ToString();
		EnemyQueue = new Queue<GameObject> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		responeTime -= Time.deltaTime;

		if (responeTime < 0)
			EnemyGenerator ();

		float newPosition = Mathf.Repeat (Time.time * playerSpeed, 6f);
		Floor.transform.position = startPosition + Vector3.left * newPosition;

		if (EnemyQueue.Count > 0)
		{
			if (EnemyQueue.Peek ().transform.position.x < -10f)
				Destroy (EnemyQueue.Dequeue ());
		}
	}

	public void PauseMenuButton()
	{
		PauseMenu.SetActive(true);
	}

	public void BacktoMenuButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
	}

	public void ContinueButton()
	{
		PauseMenu.SetActive(false);
	}

	void EnemyGenerator()
	{
		GameObject newEnemy = Instantiate(Enemy, new Vector3(10f, -2.6f, 0f), Quaternion.identity);
		newEnemy.GetComponent<EnemyScript>().moveSpeed = playerSpeed;
		newEnemy.GetComponent<EnemyScript>().elastic = 4f;
		EnemyQueue.Enqueue (newEnemy);
		responeTime = 0.7f;
	}

	public void UpdateScore(int score)
	{
		currentScore += score;
		Score.GetComponent<Text>().text = currentScore.ToString ();
	}
}
