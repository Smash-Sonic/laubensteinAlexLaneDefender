/*****************************************************************************
// File Name :         Explosion Behavior.cs
// Author :            Alex Laubenstein
// Creation Date :     September 5, 2022
//
// Brief Description : This is a script handles destroying the explosion effect.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kill()); //starts Coroutine to destroy the explosion effect
    }

    // Update is called once per frame
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject); //destroys the explosion effect

    }
}
