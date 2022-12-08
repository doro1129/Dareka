using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinalStory : MonoBehaviour
{
    public Text FinalDialogue_Text;

    private string[] FinalDialogue_String;
    private int Finaldialogue_count = 0;

    private void Start()
    {
        Set_Dialogue();
        FinalDialogue_Text.text = FinalDialogue_String[Finaldialogue_count];
        Finaldialogue_count++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Talking();
        }

        if (Finaldialogue_count == 6)
        {
            //sceneControl.OnclickStageScene();
            SceneManager.LoadScene(5);
            Finaldialogue_count = 0;
        }
    }

    public void Talking()
    {
        if (Finaldialogue_count <= 4)
        {
            FinalDialogue_Text.text = FinalDialogue_String[Finaldialogue_count];
            Finaldialogue_count++;
        }
        else if (Finaldialogue_count == 5)
        {
            FinalDialogue_Text.text = FinalDialogue_String[Finaldialogue_count - 1];
            Finaldialogue_count++;
        }
    }

    public void Set_Dialogue()
    {
        FinalDialogue_String = new string[5]
        {
        "아빠에게 모은 단서들을 다 보여주었다.",
        "아빠는 이제 나도 알아야 한다며 나를 엄마가 있는 절로 데려갔다.",
        "5년전, 내가 엄마와 아빠의 싸움을 본 날, 엄마는 아빠에게 이제 한 달도 남지 않았다고 말했다.",
        "병과 싸우며 아파하는 모습을 어린 나에게 보이고 싶지 않았던 엄마는 집을 떠났다.",
        "아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ"
        };
    }
}
