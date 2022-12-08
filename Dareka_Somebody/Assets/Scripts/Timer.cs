using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text game_Timer;
    //public GameObject GameOverText; // Time Over 시간 초과
    public GameOver gameover;
    //public GameObject GameOver_UI;

    bool isOver = false;

    private void Awake()
    {
        isOver = false;
        game_Timer = GetComponent<Text>();
    }

    private void Update()
    {
        if (!CleaningManager.isClear && SceneManager.GetActiveScene().buildIndex == 3)
        {
            GoTimer();
        }
        else if (!MamemakiManager.isClear && SceneManager.GetActiveScene().buildIndex == 4)
        {
            GoTimer();
        }
    }

    private void GoTimer()
    {
        LimitTime -= Time.deltaTime;
        game_Timer.text = "남은 시간 : " + Mathf.Round(LimitTime);

        if (LimitTime <= 0.1f)
        {
            //GameOverText.SetActive(true);
            game_Timer.text = "Game Over";
            if (!isOver)
            {
                isOver = true;
                gameover.CallGameOverMenu();
                Debug.Log("Game Over");
            }
        }
        else
        {
            if (!GameManager.isPaused)
            {
                //GameOverText.SetActive(false);
                gameover.CloseGameOverMenu();
            }
        }
    }
}