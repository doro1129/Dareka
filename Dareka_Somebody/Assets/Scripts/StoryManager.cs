using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StoryManager : MonoBehaviour
{
    //public GameObject Dialogue_Window;
    public Text StartingDialogue_Text;
    //public Text[] Dialog_Speaker;

    private string[] StartingDialogue_String;
    private int dialogue_count = 0;

    private void Start()
    {
        Set_Dialogue();
        StartingDialogue_Text.text = StartingDialogue_String[dialogue_count];
        dialogue_count++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Talking();
        }
        if (dialogue_count == 6)
        {
            SceneManager.LoadScene(1);
            dialogue_count = 0;
        }
    }

    public void Talking()
    {
        if (dialogue_count <= 4)
        {
            StartingDialogue_Text.text = StartingDialogue_String[dialogue_count];
            dialogue_count++;
        }
        else if (dialogue_count == 5)
        {
            StartingDialogue_Text.text = StartingDialogue_String[dialogue_count-1];
            dialogue_count++;
        }
    }

    public void Set_Dialogue()
    {
        StartingDialogue_String = new string[5]
        {
        "어느 날, 엄마가 사라졌다.",
        "아빠는 아무 말도 해주지 않아.",
        "며칠 전, 엄마와 아빠가 싸우는 걸 본 것 같아...",
        "아빠가 엄마를 쫓아낸게 분명해!",
        "단서를 발견하고 엄마를 찾으러 가자!"
        };
    }
}
