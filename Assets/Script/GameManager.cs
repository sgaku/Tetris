using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    [SerializeField] private Text highScoreText, gameOverText, showScoreText, scoreText;

    private int score;

    // public enum GameState
    // {
    //     Start,
    //     Play,
    //     GameOver,
    // }

    // public GameState CurrentGameState { get; set; }
    void Awake()
    {
        // CurrentGameState = GameState.Start;
        score = 0;
        PlayerPrefs.DeleteKey("Score");
        // Text hightext = highSc.GetComponent<Text>();
        highScoreText.text = "HighScore:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
        // hightext.text = "HighScore:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // void Initialize()
    // {
    //     score = 0;
    // }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "Score:" + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }


    public void GameOver()
    {
        Locator.i.spawn.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        showScoreText.gameObject.SetActive(true);

        //ハイスコアの判断
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
