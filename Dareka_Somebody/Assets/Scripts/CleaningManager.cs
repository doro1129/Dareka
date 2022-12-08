using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script was made to display score of the cleaning minigame
/// there are "남은 먼지 : n / 10" on top-right of display
/// </summary>
public class CleaningManager : MonoBehaviour
{
    public Text Dustscore; // Dust : 
    public Timer timer;
    //public GameObject GameClearText;
    public GameClear gameclear;
    public static bool isClear;

    private int dust_score = 0;

    private void Start()
    {
        SetDustScore();
        isClear = false;
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
        Dustscore.text = "남은 먼지  : " + dust_score.ToString() + "  /  10";
    }

    private void Update()
    {
        if(dust_score >= 10 && !isClear)
        {
            isClear = true;
            //GameClearText.SetActive(true);
            Invoke("Clear", 2.0f);
            //Time.timeScale = 0f;
        }
        else
        {
            if (!GameManager.isPaused)
            {
                //GameClearText.SetActive(false);
                gameclear.CloseGameClearMenu();
            }
        }
    }

    public void Clear() // Game Clear
    { 
        if(/*dust_score == 10 && */timer.LimitTime >= 0)
        {
            // TODO: Add UI or something. This needs more debate
            //SceneManager.LoadScene(1);
            gameclear.CallGameClearMenu();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
/*        else
        {
            gameclear.CloseGameClearMenu();
        }*/
    }
}
