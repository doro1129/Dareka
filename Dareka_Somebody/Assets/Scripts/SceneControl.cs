using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
   
    public void OnclickStageScene()
    {
        Debug.Log("Loading Stage Scene");
        SceneManager.LoadScene(1);
        GameManager.isPaused = false;
        Time.timeScale = 1f;
    }

    public void OnclickSelectStage_Souji()
    {
        Debug.Log("Loading Cleaning Minigame");
        SceneManager.LoadScene(2);
    }

    public void OnclickSelectStage_Mamemaki()
    {
        Debug.Log("Loading Mamemaki Minigame");
        //SceneManager.LoadScene(3);
    }
    /*
    public void OnclickGameItemScene()
    {
        Debug.Log("Loading Game Item Scene");
        //SceneManager.LoadScene();
    }

    public void OnclickGuessingScene()
    {
        Debug.Log("Loading Guessing Scene");
        //SceneManager.LoadScene();
    }

    public void OnclickEndingScene()
    {
        Debug.Log("Loading Ending Scene");
        //SceneManager.LoadScene();
    }
    */

    public void OnclickQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
