using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public InputField Answer_Inputfield;

    private string Answer_string;
    //private bool isCorrect;
    private string Answer = "724106";

    public void CheckPassword()
    {
        SetAnswer();

        if (Answer_string== Answer)
        {
            Debug.Log("맞췄다");
        }
        else
        {
            Debug.Log("틀렸다");
        }
    }

    private void SetAnswer()
    {
        Answer_string = Answer_Inputfield.GetComponent<InputField>().text;
    }
}
