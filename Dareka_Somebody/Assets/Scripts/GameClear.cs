using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField] private GameObject GameClearCanvas;

    public void CallGameClearMenu()
    {
        GameManager.isPaused = true;
        GameClearCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseGameClearMenu()
    {
        GameManager.isPaused = false;
        GameClearCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}