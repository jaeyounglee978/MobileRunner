using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    public GameObject SceneManager;
    public GameObject FarBGObject;
    public GameObject MiddleBGObject;
    public GameObject CloseBGObject;
    public GameObject FloorObject;
    GameSceneScript sceneScript;
    Vector3 FarBGStartPosition;
    Vector3 MiddleBGStartPosition;
    Vector3 CloseBGStartPosition;
    Vector3 FloorStartPosition;
    float farBGwidth;
    float middleBGwidth;
    float closeBGwidth;
    float floorWidth;
    public bool isScrolling;


    // Use this for initialization
    void Start()
    {
        isScrolling = true;
        FarBGStartPosition = FarBGObject.transform.position;
        //MiddleBGStartPosition = MiddleBGObject.transform.position;
        CloseBGStartPosition = CloseBGObject.transform.position;
        FloorStartPosition = FloorObject.transform.position;

        sceneScript = SceneManager.GetComponent<GameSceneScript>();

        farBGwidth = FarBGObject.GetComponent<SpriteRenderer>().bounds.size.x * 2;
        //middleBGwidth = middleBGObject.GetComponent<Sprite> ().bounds.size.x;
        closeBGwidth = CloseBGObject.GetComponent<SpriteRenderer>().bounds.size.x;
        floorWidth = FloorObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScrolling)
        {
            float farPositionDelta = Mathf.Repeat(Time.time * sceneScript.playerSpeed, farBGwidth);
            float closePositionDelta = Mathf.Repeat(Time.time * sceneScript.playerSpeed, closeBGwidth);
            float floorPositionDelta = Mathf.Repeat(Time.time * sceneScript.playerSpeed, floorWidth);

            FarBGObject.transform.position = FarBGStartPosition + Vector3.left * farPositionDelta * 0.5f;
            //MiddleBGObject.transform.position = MiddleBGStartPosition + Vector3.left * positionDelta * 0.7f;
            CloseBGObject.transform.position = CloseBGStartPosition + Vector3.left * closePositionDelta;
            FloorObject.transform.position = FloorStartPosition + Vector3.left * floorPositionDelta;
        }
    }
}
