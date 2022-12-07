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

        if (Finaldialogue_count == 4)
        {
            //sceneControl.OnclickStageScene();
            SceneManager.LoadScene(5);
            Finaldialogue_count = 0;
        }
    }

    public void Talking()
    {
        if (Finaldialogue_count <= 2)
        {
            FinalDialogue_Text.text = FinalDialogue_String[Finaldialogue_count];
            Finaldialogue_count++;
        }
        else if (Finaldialogue_count == 3)
        {
            FinalDialogue_Text.text = FinalDialogue_String[Finaldialogue_count - 1];
            Finaldialogue_count++;
        }
    }

    public void Set_Dialogue()
    {
        FinalDialogue_String = new string[3]
        {
        "아빠에게 모은 단서들을 다 보여주었다.",
        "아빠...이게 다 뭐예요?",
        "...그래, 너도 이제 알아야겠지, 같이 만나러 갈까?"
        };
    }
}
