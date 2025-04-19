using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scoreValue = 0;
    public Text score;
    [SerializeField] TextMeshProUGUI highscore;
    void Start()
    {
        UpdateScore();
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;
        checkhighscore();
    }
    void checkhighscore()
    {
        if (scoreValue > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", scoreValue);
            UpdateScore();
        }
    }
    void UpdateScore()
    {
        highscore.text = $" {PlayerPrefs.GetInt("highScore", 0)}";
    }
}
