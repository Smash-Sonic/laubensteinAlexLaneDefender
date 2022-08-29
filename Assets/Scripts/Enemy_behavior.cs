using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behavior : RepeatingbBackground
{
    //sets up necessary game objects
    bool hit = false;
    public AudioClip dead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        Destroy(gameObject);
        Vector3 camPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(dead, camPos);
    }
}
