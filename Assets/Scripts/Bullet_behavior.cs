/*****************************************************************************
// File Name :         Bullet_Behavior.cs
// Author :            Alex Laubenstein
// Creation Date :     September 5, 2022
//
// Brief Description : This is a script handles the bullet's properties.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_behavior : SpriteMovement
{

    // Update is called once per frame
    void Update()
    {
        //sets up the vector the bullet travels on
        Vector3 movement = transform.position;
        movement.x += 10 * Time.deltaTime;
        transform.position = movement;
        if (movement.x >= 15)
        {
            //if out of bounds destroy
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // if collision, destroys game object
    {
        Destroy(gameObject);
    }
}
