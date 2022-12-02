using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject collection;

    //remember the scene number for save load
    /*
    public int SceneCounter;
    public int CurrentScene;

    PlayerPrefs.SetInt("CurrentScene", "SceneIndex");
    SceneCounter = PlayerPrefs.GetInt("CurrentScene");
    */

    public void OnclickStageScene()
    {
        Debug.Log("Loading Stage Scene");
        SceneManager.LoadScene(1);
    }
    //pause - menu

    public void OnclickSelectStage_Setsubun()
    {
        Debug.Log("Loading Setsubun Scene");
        SceneManager.LoadScene(2);
    }

    public void OnclickSelectStage_Oshōgatsu()
    {
        Debug.Log("Loading Oshogatsu Scene");
        SceneManager.LoadScene(3);
    }

    public void OnclickSelectStage_SeijinnoHi()
    {
        Debug.Log("Loading SeijinnoHi Scene");
        SceneManager.LoadScene(5);
    }

    public void OnclickQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
