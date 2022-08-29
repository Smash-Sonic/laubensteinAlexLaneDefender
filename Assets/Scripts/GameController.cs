using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //all of the score related objects that I needed to define
    public int score = 0;
    public int score1 = 0;
    public Text scoreText;
    public Text scoreText1;

    void Update()
    {
        // Quits out of the game
        if (Input.GetKey(KeyCode.Escape)) { 
            Application.Quit(); 
        } 
        // Restarts the game
        else if (Input.GetKey(KeyCode.R)) { 
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); }
    }
}
    