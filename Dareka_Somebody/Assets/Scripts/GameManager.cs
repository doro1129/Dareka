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
    public Description description;
    public Text NameText; // Show object's name on dialog window
    public Text TalkText; // Show object's description on dialog window
    public GameObject scanObject; // Scannded Object
    public GameObject TalkWindow; // Dialog window
    //public Dust dust;
    
    //The name of Object
    public string ObjectName;

    // Check if ray has reached to object which has Layer named "Dust"
    public bool isScan=false;
    
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
            //TalkText.text = "This is " + ObjectName + ".";
            NameText.text = ObjectName;
            description.NameofObject = ObjectName;
            TalkText.text = description.describe(ObjectName);
        }
        TalkWindow.SetActive(isScan);
    }

    public void Clean(GameObject cleanOBJ)
    {
        scanObject = cleanOBJ;
        //Debug.Log(dust.dust_HP);
        //dust.Dec_dustHP();
        //dust.Remove_dust();
    }
}
