using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
   
    //remember the scene number for save load
    /*
    public int SceneCounter;
    public int CurrentScene;

    PlayerPrefs.SetInt("CurrentScene", "SceneIndex");
    SceneCounter = PlayerPrefs.GetInt("CurrentScene");
    */

    public void OnclickNewGame()
    {
        Debug.Log("New Game");
        SceneManager.LoadScene("StageScene");
    }

    public void OnclickSelectStage()
    {
        //Debug.Log("Loading Scene No." + Scene number);
        SceneManager.LoadScene("Samplescene");
        //SceneManager.LoadScene(scene name will be changed into scene number)
    }    

    public void OnclickQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
