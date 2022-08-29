using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle_behavior : MonoBehaviour
{
    //sets the paddle's speed
    public float speed = 5;
    public GameObject BIGSHOT;
    bool hit = false;
    public int lives;
    private Rigidbody2D rb2d;
    public AudioClip tapSound;
    public AudioClip dead;
    public Text healthText;
    public GameObject lossText;
    public GameObject restartText;
    public GameObject credText;

    // Update is called once per frame
    private void Start()
    {
        healthText.text = "Lives : " + lives.ToString();
        rb2d = GetComponent<Rigidbody2D>();
        //live count
        lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //shooting as well as the sound that goes with it
        if ((Input.GetKeyUp("space") || Input.GetMouseButtonDown(0)))
        {
            Vector3 camPos = Camera.main.transform.position;

            //shoots out a bullet and plays the sound that goes along with it
            Vector3 shotStart = transform.position;
            shotStart.y = transform.position.y + (float).5;
            Instantiate(BIGSHOT, shotStart, Quaternion.identity);
            AudioSource.PlayClipAtPoint(tapSound, camPos);

        }
    
    //yMove will be a value between -1 to 1
    float yMove = Input.GetAxis("Vertical");

        // Gets where we are in game
        Vector3 newPos = transform.position;

        // Changes the x position
        newPos.y += yMove * Time.deltaTime * speed;

        //Clamp the value in the y axis
        newPos.y = Mathf.Clamp(newPos.y, (float)-3.64686, (float)3.64686);

        // Resets the object's position
        transform.position = newPos;

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "slime") //player health decrease for brute enemy
        {
            GameController gc = GameObject.FindObjectOfType<GameController>();
            lives -= 1; //lowers health
            healthText.text = "Health : " + lives.ToString();//changes health in game
            if (lives <= 0) //if health is more than or equal to 5
            {
                Destroy(gameObject);//player is gone
                lossText.SetActive(true); //You Lose
            }
        }
    }

}
