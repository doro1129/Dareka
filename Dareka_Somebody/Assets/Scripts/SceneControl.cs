using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        SceneManager.LoadScene("SampleScene");
    }

    /*public void OnclickLoadGame()
    {
        Debug.Log("불러오기");
        SceneManager.LoadScene(SceneCounter);
    }*/
    

    public void OnclickQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
