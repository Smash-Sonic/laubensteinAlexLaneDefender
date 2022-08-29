using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingbBackground : MonoBehaviour
{
    //background speed
    public float scrollSpeed; 
    public const float ScrollHeight = 15; //background height/pixels per unit
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        //sets up a vector for the background to move across
        Vector3 pos = transform.position;
        //speed corresponds to time
        pos.x -= scrollSpeed * Time.deltaTime;

        if (transform.position.y < -ScrollHeight)
        {
            //object is offscreen
            Offscreen(ref pos);
        }
        
        transform.position = pos;
    }

    protected virtual void Offscreen(ref Vector3 pos)
    {
        //move the screen back to where it started
        pos.x += 2 * ScrollHeight;
    }
}
