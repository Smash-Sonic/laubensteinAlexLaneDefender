/*****************************************************************************
// File Name :         GameController.cs
// Author :            Alex Laubenstein
// Creation Date :     September 5, 2022
//
// Brief Description : This is a script that handles spawning enemies and handling
                       variables.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //all of the score related objects that I needed to define
    public int score=0;
    public TMP_Text scoreText;
    public static int hScore;
    public TMP_Text hScoreText;
    public int lives;
    public TMP_Text healthText;
    public GameObject explosion;
    public GameObject theEnemy;
    public GameObject theBlueEnemy;
    public GameObject theGreenEnemy;
    string highScore;

    void Start()
    {
        InvokeRepeating("Spawn", 1.5f, 2f); //spawn enemies

        lives = 3; //life count
        
        if (PlayerPrefs.HasKey(highScore))
        {
            hScore = PlayerPrefs.GetInt(highScore);
        }
        else
        {
            PlayerPrefs.SetInt(highScore, 0);
        }
    }
    void Update()
    {
        healthText.text = "Health : " + lives.ToString();//changes health in game
        scoreText.text = "Score : " + score.ToString();//changes score in game
        hScoreText.text = "High Score : " + hScore.ToString();//changes high Score in game
        if(hScore < score)
        {
            hScore = score;
            PlayerPrefs.SetInt(highScore, hScore);
            PlayerPrefs.Save();
        }

        // Quits out of the game
        if (Input.GetKey(KeyCode.Escape)) 
        { 
            Application.Quit(); 
        } 
        // Restarts the game
        else if (Input.GetKey(KeyCode.R)) 
        { 
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
        }
    }

    void Spawn()
    {
        int random = Random.Range(1, 5);
        //sets spawn position
        Vector3 spawnPos = new Vector3();
        spawnPos.x = 8;
        spawnPos.y = (Random.Range(-2, 3) * 2);
        if (random == 1)
        {
            Instantiate(theEnemy, spawnPos, Quaternion.identity); // spawns in the enemy
        }
        if (random == 2)
        {
            Instantiate(theBlueEnemy, spawnPos, Quaternion.identity); // spawns in the enemy
        }
        if (random == 3)
        {
            Instantiate(theGreenEnemy, spawnPos, Quaternion.identity); // spawns in the enemy
        }
    }
}
    