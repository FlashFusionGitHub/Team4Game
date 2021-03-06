﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenActor : MonoBehaviour {

	public Button restartButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {



	}

	void Exit() {
		Application.Quit ();
	}

	void Restart() {
		SceneManager.LoadScene (0);
	}
}
