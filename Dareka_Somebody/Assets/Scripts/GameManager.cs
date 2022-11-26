using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager scan objects
/// </summary>
public class GameManager : MonoBehaviour
{
    // It will update Text
    public Description description;
    public Text NameText; // Show object's name on dialog window
    public Text TalkText; // Show object's description on dialog window
    public GameObject TalkWindow; // Dialog window

    public Text Dustscore1; // Dust : 
    public Text Dustscore2; // / 10

    //The name of Object
    public string ObjectName;

    // Check if ray has reached to object which has Layer named "Dust"
    public bool isScan=false;

    private GameObject scanObject; // Scannded Object
    private int dust_score = 0;

    private void Start()
    {
        SetDustScore();
    }

    public void GetDustScore()
    {
        dust_score += 1;
        SetDustScore();
    }

    private void SetDustScore()
    {
        Dustscore1.text = "남은 먼지 : " + dust_score.ToString();
    }

    public void Scan(GameObject scanOBJ)
    {
        if (isScan)
        {
            isScan = false;
        }
        else
        {
            isScan = true;
            
            TalkWindow.SetActive(true);

            scanObject = scanOBJ;
            ObjectName = scanObject.name;

            NameText.text = ObjectName;
            description.NameofObject = ObjectName;
            TalkText.text = description.describe(ObjectName);
        }
        TalkWindow.SetActive(isScan);
    }

    public void Clean()
    {

    }
}
