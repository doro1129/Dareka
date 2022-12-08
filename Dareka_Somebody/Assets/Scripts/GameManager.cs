using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public static GameManager instance;

    public List<bool> collections = new List<bool>();
    public List<int> oshogatsuCollections = new List<int>();
    public List<int> setsubunCollections = new List<int>();

    public List<string> collectionsProps = new List<string>();
    public List<string> collectionsDescriptions = new List<string>();

    private void Awake()
    {
        instance = this;
    }

    //Pause Menu
    public string ObjectName; //The name of Object
    public bool isScan = false; // Check if ray has reached to object which has Layer named "Dust"

    //Pause Menu
    public static bool isPaused = false;

    private GameObject scanObject; // Scannded Object

    private void Update()
    {
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Scan objects and Outputs UI on display
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
}
