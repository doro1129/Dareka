using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Move to 2nd Target
/// </summary>
public class TakeStairs : MonoBehaviour
{
    // Move Player to Taget's position
    public Transform Target;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            col.transform.position = Target.position;
        }
    }
}
