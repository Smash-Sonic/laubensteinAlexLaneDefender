/*****************************************************************************
// File Name :         SpriteMovenment.cs
// Author :            Alex Laubenstein
// Creation Date :     September 5, 2022
//
// Brief Description : This is a script handles moving both the bullets 
                       and the enemies.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    //enemy speed
    public float enemySpeed; 
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        //sets up a vector for the sprites to move across
        Vector3 pos = transform.position;
        //speed corresponds to time
        pos.x -= enemySpeed * Time.deltaTime;
        transform.position = pos;
    }
}
