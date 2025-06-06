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
        SceneManager.LoadScene("Intro");
    }

    public void loadForestScene()
    {
        SceneManager.LoadScene("ForestMaze");
    }

    public void HouseTwoScene()
    {
        SceneManager.LoadScene("HouseTwo");
    }


    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }









}