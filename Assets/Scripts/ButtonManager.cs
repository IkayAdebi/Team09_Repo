using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private string currentStage = "MainScene";

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restartGame()
    {
        SceneManager.LoadScene(currentStage);
    }

    public void stage1()
    {
        currentStage = "MainScene";
        SceneManager.LoadScene("MainScene");
    }

    public void stage2()
    {
        currentStage = "Stage2";
        SceneManager.LoadScene("MainScene - Copy");

    }

    public void stage3()
    {
        currentStage = "Stage3";
        SceneManager.LoadScene("MainScene - Copy - Copy");

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("start");
    }

    public void howTo()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
