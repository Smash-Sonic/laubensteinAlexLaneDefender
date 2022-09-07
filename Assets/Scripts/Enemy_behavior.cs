/*****************************************************************************
// File Name :         Enemy_Behavior.cs
// Author :            Alex Laubenstein
// Creation Date :     September 5, 2022
//
// Brief Description : This is a script that handles all the enemies and their
                       major functions in game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behavior : SpriteMovement
{
    //sets up necessary game objects
    public AudioClip dead;
    public AudioClip hit;
    public int enemyHP;
    public int Score;
    public GameObject enemyReference;

    private void Start()
    {
        //sets all the variables for the enemies
        if (gameObject.name == "slime(Clone)")
        {
            enemyHP = 1;
            enemySpeed = 3;
            Score = 1;
        }
        if (gameObject.name == "slimeBlue(Clone)")
        {
            enemyHP = 3;
            enemySpeed = 2;
            Score = 3;
        }
        if (gameObject.name == "slimeGreen(Clone)")
        {
            enemyHP = 5;
            enemySpeed = 1;
            Score = 5;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        Vector3 camPos = Camera.main.transform.position;
        Vector3 exploStart = transform.position;
        Instantiate(gc.explosion, exploStart, Quaternion.identity);
        if (collision.gameObject.name == "wall" || collision.gameObject.name == "Tank") //if the enemy hits the wall or player, kill the slime and play the sfx
        {
            Destroy(gameObject); //kills slime
            AudioSource.PlayClipAtPoint(dead, camPos);
        }
        if (collision.gameObject.name == "wall")//if the enemy hits the wall lose a life
        {
            gc.lives -= 1; //lowers health
            gc.healthText.text = "Health : " + gc.lives.ToString();//changes health in game
        }
        if (collision.gameObject.name == "tank_bullet(Clone)") //slime health decrease and activates hitstop
        {
            StartCoroutine(HitStop());
            enemyHP--;
            AudioSource.PlayClipAtPoint(hit, camPos);
        }
        if (enemyHP <= 0) //kills enemy if health is too low
        {
            gc.score += Score;
            Destroy(gameObject);
        }
        IEnumerator HitStop()
        {
            enemySpeed = 0; //stops the enemy
            enemyReference.GetComponent<SpriteRenderer>().color = new Color(1, 0.1f, 0.1f); //shows the enemy got hit
            yield return new WaitForSecondsRealtime(0.1f); //waits for the enemy to move again

            if (gameObject.name == "slime")
            {
                enemySpeed = 3;
            }
            if (gameObject.name == "slimeBlue(Clone)")
            {
                enemySpeed = 2;
            }
            if (gameObject.name == "slimeGreen(Clone)")
            {
                enemySpeed = 1;
            }
            enemyReference.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //stops showing that the enemy got hit
        }
    }
}
