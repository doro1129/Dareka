using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public Canvas guess_canvas;
    public Canvas vocabulary_canvas;
    public CanvasGroup guess;
    public CanvasGroup vocabulary;

    public void OnclickStageScene()
    {
        Debug.Log("Loading Stage Scene");
        SceneManager.LoadScene(1);
        GameManager.isPaused = false;
        Time.timeScale = 1f;
    }

    //StartScene

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

    /*

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

   /* void Awake()
    {
        guess.alpha = 0;
        guess_canvas.enabled = false;

        vocabulary.alpha = 0;
        vocabulary_canvas.enabled = false;
    }
   */
    public void OnclickGuessActive()
    {
        Debug.Log("Loading Guess UI");
        guess.alpha = 1;
        guess.interactable = true;
        guess_canvas.enabled = true;
        vocabulary_canvas.enabled = false;
    }

    public void OnclickVocabularyActive()
    {
        Debug.Log("Loading Vocabulary UI");
        vocabulary.alpha = 1;
        vocabulary.interactable = true;
        guess_canvas.enabled = false;
        vocabulary_canvas.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            guess.alpha = 0;
            guess.interactable = false;
            guess_canvas.enabled = false;

            vocabulary.alpha = 0;
            vocabulary.interactable = false;
            vocabulary_canvas.enabled = false;
        }
    }
}
