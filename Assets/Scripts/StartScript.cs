using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    public GameObject SceneManager;
    GameSceneScript sceneManager;
    CameraScript cameraScript;
    public GameObject Player;
    public GameObject Floor;
    public GameObject StartStage;
    public GameObject Camera;
    bool ready;
    bool coroutineRunning;
    float moveSpeed = 4;

    // Use this for initialization
    void Start()
    {
        sceneManager = SceneManager.GetComponent<GameSceneScript>();
        cameraScript = Camera.GetComponent<CameraScript>();
        cameraScript.cameraWork = false;
        sceneManager.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        Player.transform.position += Player.GetComponent<CharacterScript>().velocity * Time.deltaTime;

        if (Player.transform.position.x <= 0)
        {
            Player.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            StartStage.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            Floor.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            Vector2 cameraPos = new Vector2(Camera.transform.position.x, Camera.transform.position.y);
            Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);

            if ((cameraPos - playerPos).magnitude >= 0.05f)
            {

                Camera.transform.position = Vector3.MoveTowards(Camera.transform.position,
                                                        new Vector3(Player.transform.position.x, Player.transform.position.y, -10),
                                                        1.0f * Time.deltaTime);

                cameraPos = Camera.transform.position;
                playerPos = Player.transform.position;

                if ((cameraPos - playerPos).magnitude <= 0.05f)
                {
                    cameraScript.cameraWork = true;
                }
            }


            if (StartStage.transform.position.x >= -5f)
            {
                StartStage.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                Floor.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                if (Player.GetComponent<CharacterScript>().velocity.y <= 0)
                    Player.GetComponent<CharacterScript>().velocity += Vector3.up * 2;

                if (StartStage.transform.position.x >= -11f)
                {
                    StartStage.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                    Floor.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    StartStage.SetActive(false);
                    sceneManager.SetFloorPosition();
                    sceneManager.isPlaying = true;
                    this.enabled = false;
                }
            }
        }

    }
}
