using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FirstStory : MonoBehaviour
{
    public Text StartingDialogue_Text;

    private string[] StartingDialogue_String;
    private int Startingdialogue_count = 0;

    private void Start()
    {
        Set_Dialogue();
        StartingDialogue_Text.text = StartingDialogue_String[Startingdialogue_count];
        Startingdialogue_count++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Talking();
        }

        if (Startingdialogue_count == 8)
        {
            //sceneControl.OnclickStageScene();
            SceneManager.LoadScene(2);
            Startingdialogue_count = 0;
        }
    }

    public void Talking()
    {
        if (Startingdialogue_count <= 6)
        {
            StartingDialogue_Text.text = StartingDialogue_String[Startingdialogue_count];
            Startingdialogue_count++;
        }
        else if (Startingdialogue_count == 7)
        {
            StartingDialogue_Text.text = StartingDialogue_String[Startingdialogue_count - 1];
            Startingdialogue_count++;
        }
    }

    public void Set_Dialogue()
    {
        StartingDialogue_String = new string[7]
        {
        "어느 날, 엄마가 사라졌다.",
        "아빠는 아무 말도 해주지 않아.",
        "며칠 전, 엄마와 아빠가 싸우는 걸 본 것 같아...",
        "아빠가 엄마를 쫓아낸게 분명해!",
        "단서를 발견하고 엄마를 찾으러 가자!",
        "[정월/세쓰분 미니게임을 클리어하고 아이템을 얻을 수 있습니다.]",
        "[얻은 아이템을 콜렉션에서 확인하고 추리 버튼을 눌러 문제를 풀어보세요!]"
        };
    }
}
