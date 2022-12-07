using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject Guess;
    public GameObject Collection;
    
    public void OnclickSelectStage_FirstStory()
    {
        Debug.Log("Loading FirstStory");
        SceneManager.LoadScene(1);
    }

    public void OnclickStageScene()
    {
        Debug.Log("Loading Stage Scene");
        SceneManager.LoadScene(2);
        GameManager.isPaused = false;
        Time.timeScale = 1f;
    }

    //StartScene
    public void OnclickSelectStage_Souji()
    {
        Debug.Log("Loading Cleaning Minigame");
        SceneManager.LoadScene(3);
    }

    public void OnclickSelectStage_Mamemaki()
    {
        Debug.Log("Loading Mamemaki Minigame");
        SceneManager.LoadScene(4);
    }

    public void OnclickQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnclickGuessActive()
    {
        Debug.Log("Loading Guess UI");
        Guess.SetActive(true);
        Collection.SetActive(false);
    }

    public void OnclickVocabularyActive()
    {
        Debug.Log("Loading Vocabulary UI");
        Guess.SetActive(false);
        Collection.SetActive(true);
    }

    void Update()
    {
        if (Guess != null && Collection != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Guess.SetActive(false);
                Collection.SetActive(false);
            }
        }
    }
}
