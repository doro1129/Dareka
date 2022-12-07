using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.isPaused)
            {
                CallMenu();
                Debug.Log("Paused");

            }
            else
            {
                CloseMenu();
                Debug.Log("Resume");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void CallMenu()
    {
        GameManager.isPaused = true;
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private void CloseMenu()
    {
        GameManager.isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

}
