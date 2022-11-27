using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text game_Timer;
    public GameObject GameOver;

    private void Update()
    {
        LimitTime -= Time.deltaTime;
        game_Timer.text = "남은 시간 : " + Mathf.Round(LimitTime);

        if (LimitTime <= 0)
        {
            GameOver.SetActive(true);
            game_Timer.text = "Game Over";
            if (LimitTime <= -3)
            {
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            GameOver.SetActive(false);
        }
    }
}