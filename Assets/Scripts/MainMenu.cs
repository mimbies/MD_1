using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /*public Button exitButton;
    public Button startButton;
    public Button creditsButton;
    public Button skipButton;*/

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void loadForestScene()
    {
        SceneManager.LoadScene(1);
    }








}