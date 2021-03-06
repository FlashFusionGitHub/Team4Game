﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenActor : MonoBehaviour {

    public Button startbutton;
    public Button exitButton;


    // Use this for initialization
    void Start () {
        exitButton.onClick.AddListener(Exit);
        startbutton.onClick.AddListener(StartGame);

    }

    // Update is called once per frame
    void Update () {

    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Exit()
    {
        Application.Quit();
    }
}
