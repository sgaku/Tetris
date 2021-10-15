using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject spawn;
    public GameObject sc,highsc;
    public GameObject go, showsc;



    public  Text scoreText;
    private int score;
     void Awake()
    {
        Initailize();
        PlayerPrefs.DeleteKey("Score");
      Text hightext =    highsc.GetComponent<Text>();
        hightext.text =  "HighScore:"+PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Initailize()
    {
        score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "Score:" + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }


    public void GameOver()
    {
        spawn.SetActive(false);
        sc.SetActive(false);
        highsc.SetActive(false);

        go.SetActive(true);
        showsc.SetActive(true);
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        
    }
}
