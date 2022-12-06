using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Grading : MonoBehaviour
{
    public List<InputField> Answer = new List<InputField>(new InputField[4]);

    private List<string> Answer_string = new List<string>(new string[4]);
    private int score = 0;
    private string[] Answers = new string[4] { "1", "2", "3", "4" };

    public void Grade()
    {
        SetAnswer();

        for (int i = 0; i <= 3; i++)
        {
            if (Answer_string[i] == Answers[i])
            {
                score += 25;
            }
        }
        Debug.Log(score);
        score = 0;
    }

    private void SetAnswer()
    {
        for(int i = 0; i <= 3; i++)
        {
            Answer_string[i] = Answer[i].GetComponent<InputField>().text;
        }
    }
}
