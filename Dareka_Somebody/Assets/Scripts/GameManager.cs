using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager scan objects
/// </summary>
public class GameManager : MonoBehaviour
{
    // It will update Text
    public Text TalkText;
    public GameObject scanObject; // 스캔된 물체
    public GameObject TalkWindow; // 대화창
    
    //The name of Object
    public string ObjectName;

    // Check if ray has reached to object which has Layer named "whatisObject"
    public bool isScan=true;
    

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

            // Temporary speech
            TalkText.text = "This is " + ObjectName + ".";
        }
        TalkWindow.SetActive(isScan);
    }
}
