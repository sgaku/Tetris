using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{


    public  Text scoreText;
    private int score;
     void Awake()
    {
        Initailize();
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
    }
}
