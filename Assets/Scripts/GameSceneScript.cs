using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Floor;
    public GameObject Score;
    public List<GameObject> Enemies;
    int currentScore;
    float respawnTime;
    public float playerSpeed;
    Vector3 startPosition;
    Queue<GameObject> EnemyQueue;
    public bool isPlaying;
    BackgroundScript bgScript;
    Vector3 enemyBasePosition = new Vector3(10f, -3.2f, 0f);

    // Use this for initialization
    void Start()
    {
        PauseMenu.SetActive(false);
        respawnTime = 1.0f;
        playerSpeed = 5.0f;

        currentScore = 0;
        Score.GetComponent<Text>().text = currentScore.ToString();
        EnemyQueue = new Queue<GameObject>();
        bgScript = GetComponent<BackgroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            respawnTime -= Time.deltaTime;

            if (respawnTime < 0)
                EnemyGenerator();

            float newPosition = Mathf.Repeat(Time.time * playerSpeed, 6f);
            Floor.transform.position = startPosition + Vector3.left * newPosition;

            if (EnemyQueue.Count > 0)
            {
                if (EnemyQueue.Peek().transform.position.x < -10f)
                    Destroy(EnemyQueue.Dequeue());
            }
        }
    }

    public void PauseMenuButton()
    {
        PauseMenu.SetActive(true);
        isPlaying = false;
        bgScript.isScrolling = false;
    }

    public void BacktoMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

    public void ContinueButton()
    {
        PauseMenu.SetActive(false);
        isPlaying = true;
        bgScript.isScrolling = true;
    }

    void EnemyGenerator()
    {
        /*
		Vector3 enemyPosition = new Vector3 (10f, -3.2f, 0f);
		enemyPosition += Vector3.up * Enemy1.GetComponent<SpriteRenderer> ().bounds.size.y;
		GameObject newEnemy = Instantiate(Enemy1, enemyPosition, Quaternion.identity);

        newEnemy.GetComponent<EnemyScript>().moveSpeed = playerSpeed;
        newEnemy.GetComponent<EnemyScript>().elastic = 4f;
        EnemyQueue.Enqueue(newEnemy);
        respawnTime = 0.7f;*/


        if (currentScore <= 100)
        {
            Vector3 enemyPosition = enemyBasePosition + Vector3.up * Enemy1.GetComponent<SpriteRenderer>().bounds.size.y;
            GameObject newEnemy = Instantiate(Enemy1, enemyPosition, Quaternion.identity);
            newEnemy.GetComponent<EnemyScript>().moveSpeed = playerSpeed;
            EnemyQueue.Enqueue(newEnemy);
            respawnTime = Enemy1.GetComponent<EnemyScript>().nestRespawn;

        }
        else if (currentScore <= 300)
        {
            int r = Random.Range(0, 10);

            GameObject Enemy;
            Vector3 enemyPosition;

            if (r <= 7)
            {
                Enemy = Enemy1;
                enemyPosition = enemyBasePosition + Vector3.up * Enemy.GetComponent<SpriteRenderer>().bounds.size.y;
            }
            else
            {
                Enemy = Enemy2;
                enemyPosition = enemyBasePosition + Vector3.up * Enemy.GetComponent<SpriteRenderer>().bounds.size.y;
                enemyPosition -= Vector3.up * 0.2f;
            }

            GameObject newEnemy = Instantiate(Enemy, enemyPosition, Quaternion.identity);
            newEnemy.GetComponent<EnemyScript>().moveSpeed = playerSpeed;
            EnemyQueue.Enqueue(newEnemy);
            respawnTime = Enemy.GetComponent<EnemyScript>().nestRespawn;
        }
        else
        {
            int r = Random.Range(0, 10);

            GameObject Enemy;
            Vector3 enemyPosition;

            if (r <= 4)
            {
                Enemy = Enemy1;
                enemyPosition = enemyBasePosition + Vector3.up * Enemy.GetComponent<SpriteRenderer>().bounds.size.y;
            }
            else if (4 < r && r <= 8)
            {
                Enemy = Enemy2;
                enemyPosition = enemyBasePosition + Vector3.up * Enemy.GetComponent<SpriteRenderer>().bounds.size.y;
                enemyPosition -= Vector3.up * 0.25f;
            }
            else
            {
                Enemy = Enemy3;
                enemyPosition = enemyBasePosition + Vector3.up * Enemy.GetComponent<SpriteRenderer>().bounds.size.y;
                enemyPosition -= Vector3.up * 0.6f;
            }

            GameObject newEnemy = Instantiate(Enemy, enemyPosition, Quaternion.identity);
            newEnemy.GetComponent<EnemyScript>().moveSpeed = playerSpeed;
            EnemyQueue.Enqueue(newEnemy);
            respawnTime = Enemy.GetComponent<EnemyScript>().nestRespawn;
        }
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        Score.GetComponent<Text>().text = currentScore.ToString();
    }

    public void SetFloorPosition()
    {
        startPosition = Floor.transform.position;
    }
}
