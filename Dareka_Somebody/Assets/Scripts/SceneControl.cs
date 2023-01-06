using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject Setting;
    public GameObject Guess;
    public GameObject Collection;

    public GameObject vocabulary;
    VocabularyList vocabularyList;

    public AudioClip clickClip;
    public GameOver gameOver;
    public GameObject diary;

    private bool isSetting_open = false;

    private void Start()
    {
        if (vocabulary != null)
        {
            vocabularyList = vocabulary.GetComponent<VocabularyList>();
        }
    }

    public void OnclickSelectStage_Title()
    {
        Debug.Log("Loading Title");
        SoundManager.instance.SFXPlay("Click", clickClip);
        SceneManager.LoadScene(0);
    }

    public void OnclickSelectStage_FirstStory()
    {
        Debug.Log("Loading FirstStory");
        SoundManager.instance.SFXPlay("Click", clickClip);
        SceneManager.LoadScene(1);
    }

    public void OnclickStageScene()
    {
        Debug.Log("Loading Stage Scene");
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            SoundManager.instance.SFXPlay("Click", clickClip);
        }
        SceneManager.LoadScene(2);
        GameManager.isPaused = false;
        Time.timeScale = 1f;
    }

    //StartScene
    public void OnclickSelectStage_Souji()
    {
        Debug.Log("Loading Cleaning Minigame");
        SoundManager.instance.SFXPlay("Click", clickClip);
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            gameOver.CloseGameOverMenu();
        }
        SceneManager.LoadScene(3);
    }

    public void OnclickSelectStage_Mamemaki()
    {
        Debug.Log("Loading Mamemaki Minigame");
        SoundManager.instance.SFXPlay("Click", clickClip);
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            gameOver.CloseGameOverMenu();
        }
        SceneManager.LoadScene(4);
    }

    public void OnclickQuitGame()
    {
        Debug.Log("Quit");
        SoundManager.instance.SFXPlay("Click", clickClip);
        Application.Quit();
    }

    public void OnclickSettingActive()
    {
        Debug.Log("Loading Setting UI");
        if (isSetting_open == false)
        {
            isSetting_open = true;
            Setting.SetActive(true);
        }
        else
        {
            isSetting_open = false;
            Setting.SetActive(false);
        }
        SoundManager.instance.SFXPlay("Click", clickClip);
    }

    public void OnclickGuessActive()
    {
        Debug.Log("Loading Guess UI");
        Guess.SetActive(true);
        Collection.SetActive(false);
        SoundManager.instance.SFXPlay("Click", clickClip);
    }

    public void OnclickVocabularyActive()
    {
        Debug.Log("Loading Vocabulary UI");
        Guess.SetActive(false);
        Collection.SetActive(true);
        vocabularyList.UpdateCollection();
        SoundManager.instance.SFXPlay("Click", clickClip);
    }

    void Update()
    {
        if (Guess != null && Collection != null && diary != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Guess.SetActive(false);
                Collection.SetActive(false);
                diary.SetActive(false);
            }
        }
    }
}
