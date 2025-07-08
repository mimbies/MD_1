using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button exitButton;
    public Button startButton;
    public Button chapterButton;
    public Button creditsButton;

    public Button backToMenuButton;
    public Button forestButton;
    public Button starButton;
    public Button buttonButton;
    public Button potionButton;

    //kapitel auswahl
    public GameObject mainMenuPanel;
    public GameObject kapitelPanel;
    public GameObject overlay;



    public void exitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    public void startGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void openChapterSelection()
    {
        mainMenuPanel.GetComponent<CanvasGroup>().interactable = false;
        mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

        kapitelPanel.SetActive(true);
        overlay.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(forestButton.gameObject);
    }
    public void closeChapterSelection()
    {
        mainMenuPanel.GetComponent<CanvasGroup>().interactable = true;
        mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

        kapitelPanel.SetActive(false);
        overlay.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(chapterButton.gameObject);

    }

    public void loadForestScene()
    {
        SceneManager.LoadScene("ForestMaze");
    }

    public void HouseTwoScene()
    {
        SceneManager.LoadScene("HouseTwo");
    }

    public void CatchTheStarsScene()
    {
        SceneManager.LoadScene("CatchTheStars");
    }


    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void loadButtonPuzzle()
    {
        SceneManager.LoadScene("Buttonpuzzle");
    }
    public void loadPotionEnd()
    {
        SceneManager.LoadScene("HouseEnding");
    }







}