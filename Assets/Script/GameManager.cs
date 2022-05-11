using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] private Text highScoreText, gameOverText, showScoreText, scoreText;
    [SerializeField] private GameObject[] blocks;

    [SerializeField] private Transform createPosition;
    [SerializeField] private Transform blocksParent;
    public Transform BlocksParent
    {
        get => blocksParent;
        private set => blocksParent = value;
    }

    private int score;

    public enum GameState
    {
        Start,
        Play,
        GameOver,
    }

    public GameState CurrentGameState { get; set; }
    void Awake()
    {
        CurrentGameState = GameState.Start;
        score = 0;
        PlayerPrefs.DeleteKey("Score");
        highScoreText.text = "HighScore:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        // Debug.Log(CurrentGameState);
        if (CurrentGameState == GameState.Start && Input.GetMouseButtonDown(0))
        {
            CurrentGameState = GameState.Play;
            CreateBlock();
        }
        if (CurrentGameState == GameState.GameOver)
        {
            GameOver();
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        };
    }

    public void CreateBlock()
    {
        Instantiate(blocks[Random.Range(0, blocks.Length)], createPosition.position, Quaternion.identity);
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "Score:" + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }


    void GameOver()
    {
        blocksParent.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        showScoreText.gameObject.SetActive(true);
        showScoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();

        //ハイスコアの判断
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
