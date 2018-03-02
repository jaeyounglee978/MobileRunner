using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
