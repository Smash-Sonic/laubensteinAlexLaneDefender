/*****************************************************************************
// File Name :         Tank_Behavior.cs
// Author :            Alex Laubenstein
// Creation Date :     September 5, 2022
//
// Brief Description : This is a script that handles all the tank's major functions
                       in game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tank_behavior : MonoBehaviour
{
    //sets the paddle's speed
    public float speed = 5;
    public GameObject bullet;
    public AudioClip shotSound;
    public AudioClip hurt;
    public AudioClip dead;
    public TMP_Text lossText;
    public Transform bulletOffset;
    public bool Shootable;


    private void Start()
    {
        Shootable = true; //sets the boolean to allow shooting
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = Camera.main.transform.position; //sets up the vector for sound
        GameController gc = GameObject.FindObjectOfType<GameController>();
        //shooting as well as the sound that goes with it
        if (Input.GetKey("space"))
        {
            if (Shootable == true)
            {
                //shoots out a bullet and plays the sound and produces the effects that go along with it
                Vector3 shotStart = transform.position;
                Vector3 exploStart = transform.position;
                shotStart.x = transform.position.x + (float)1.25;
                exploStart.x = transform.position.x + (float)1.25;
                Instantiate(gc.explosion, exploStart, Quaternion.identity);
                Instantiate(bullet, shotStart, Quaternion.identity);
                Shootable = false;
                AudioSource.PlayClipAtPoint(shotSound, camPos); //plays sfx
                StartCoroutine(Timer()); //sets a delay for constant shooting
            }
        }

        IEnumerator Timer() //sets a delay for constant shooting
        {
            yield return new WaitForSecondsRealtime(1);
            Shootable = true;
        }
        //yMove will be a value between -1 to 1
        float yMove = Input.GetAxis("Vertical");

        // Gets where we are in game
        Vector3 newPos = transform.position;

        // Changes the y position
        newPos.y += yMove * Time.deltaTime * speed;

        //Clamp the value in the y axis
        newPos.y = Mathf.Clamp(newPos.y, (float)-4, (float)4);

        // Resets the object's position
        transform.position = newPos;

        if (gc.lives <= 0) //if lives are less than or equal to 0
        {
            Destroy(gameObject);//player is gone
            lossText.gameObject.SetActive(true); //You Lose
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "slime(Clone)" || collision.gameObject.name == "slimeBlue(Clone)" || collision.gameObject.name == "slimeGreen(Clone)") //player health decrease for enemy
        {
            GameController gc = GameObject.FindObjectOfType<GameController>();
            gc.lives -= 1; //lowers health
            gc.healthText.text = "Health : " + gc.lives.ToString();//changes health in game
        }
    }

}
