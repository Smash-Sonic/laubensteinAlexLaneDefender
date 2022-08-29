using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_behavior : RepeatingbBackground
{
    bool hit = false;

    // Update is called once per frame
    void Update()
    {
        //sets up the vector the bullet travels on
        Vector3 movement = transform.position;
        movement.x += 10 * Time.deltaTime;
        transform.position = movement;
        if (movement.y >= 15)
        {
            //if out of bounds destroy
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // if collision, destroy game object
    {
        hit = true;
        Destroy(gameObject);
    }
}
