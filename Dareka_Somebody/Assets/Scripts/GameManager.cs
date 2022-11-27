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

    public Text Dustscore1; // Dust : 
    public Text Dustscore2; // / 10

    //The name of Object
    public string ObjectName;

    // Check if ray has reached to object which has Layer named "Dust"
    public bool isScan=false;
    public Timer timer;

    private GameObject scanObject; // Scannded Object
    private int dust_score = 0;

    private void Start()
    {
        SetDustScore();
    }

    // Add 1 at dustscore and invoke SetDustScore()
    public void GetDustScore()
    {
        dust_score += 1;
        SetDustScore();
    }

    // Set dustscore1 text
    private void SetDustScore()
    {
        Dustscore1.text = "남은 먼지 : " + dust_score.ToString();
    }

    private void Update()
    {
        Clear();
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

    // If dust_score were 10, this function will end 'Cleaning' scene.
    // If dust_score is 10 and time left is more than 0, SceneManager will load stage select scene.
    public void Clear()
    {
        if(dust_score == 10 && timer.LimitTime >= 0)
        {
            // TODO: Add UI or something. This needs more debate
            SceneManager.LoadScene(1);
        }
    }
}
