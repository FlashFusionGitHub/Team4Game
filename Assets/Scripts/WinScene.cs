using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour {

    public Button restartButton;
    public Button exitButton;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Exit()
    {
        Application.Quit();
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
