using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject Next_Button;
    private float height = 115.5f;
    
    void FixedUpdate()
    {
        if (height <= 120)
        {
            height += 0.13f;
            Next_Button.transform.position = new Vector3(1760f, height, 0);

        }
        else if (height >= 120)
        {
            height = 115.5f;
            Next_Button.transform.position = new Vector3(1760f, height, 0);
        }
    }
}
