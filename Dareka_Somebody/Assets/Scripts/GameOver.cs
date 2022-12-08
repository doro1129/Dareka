using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverCanvas;
    public AudioClip gameoverClip;

    public void CallGameOverMenu()
    {
        SoundManager.instance.SFXPlay("GameOver", gameoverClip);
        GameManager.isPaused = true;
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseGameOverMenu()
    {
        GameManager.isPaused = false;
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
