using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text game_Timer;
    public GameObject GameOverText; // Time Over 시간 초과
    public GameOver gameover;
    //public GameObject GameOver_UI;


    private void Update()
    {
        if (!CleaningManager.isClear)
        {
            LimitTime -= Time.deltaTime;
            game_Timer.text = "남은 시간 : " + Mathf.Round(LimitTime);

            if (LimitTime <= 0.5f)
            {
                GameOverText.SetActive(true);
                game_Timer.text = "Game Over";
                if (LimitTime <= -2)
                {
                    gameover.CallGameOverMenu();
                    Debug.Log("Game Over");
                }
            }
            else
            {
                if (!GameManager.isPaused)
                {
                    GameOverText.SetActive(false);
                    gameover.CloseGameOverMenu();
                }
            }
        }
    }
}