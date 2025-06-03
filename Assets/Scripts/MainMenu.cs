using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button exitButton;
    public Button startButton;
    public Button creditsButton;


    public void exitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void loadForestScene()
    {
        SceneManager.LoadScene(3);
    }

    public void HouseTwoScene()
    {
        SceneManager.LoadScene(4);
    }


    public void credits()
    {
        SceneManager.LoadScene(2);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(1);
    }









}