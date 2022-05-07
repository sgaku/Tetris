using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour
{
    public Text showscore;
    // Update is called once per frame
    void Update()
    {
        showscore.text = "Your Score:" + PlayerPrefs.GetInt("Score", 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
