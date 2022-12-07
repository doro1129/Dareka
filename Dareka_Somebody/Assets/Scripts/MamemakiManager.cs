using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script was made to display score of the cleaning minigame
/// there are "남은 먼지 : n / 10" on top-right of display
/// </summary>
public class MamemakiManager : MonoBehaviour
{
    public Slider playerHPBar;
    public Timer timer;
    public GameObject GameClearText;
    public GameClear gameclear;
    public GameOver gameover;
    public static bool isClear = false;
    public GameObject player;
    FPSPlayer playerLogic;
    public GameObject canvas;
    OniSpawner oniSpawner;

    private void Start()
    {
        playerLogic = player.GetComponent<FPSPlayer>();
        oniSpawner = canvas.GetComponent<OniSpawner>();
    }

    private void Update()
    {
        if (playerLogic.hp <= 0)
        {
            playerHPBar.value = 0f;

            gameover.CallGameOverMenu();
        }
        else
        {
            if (playerHPBar != null)
            {
                HandleHPBar();
            }
        }

        if (oniSpawner.deathOni >= oniSpawner.enemies.Count)
        {
            isClear = true;
            Invoke("Clear", 2.0f);
            //Time.timeScale = 0f;
        }
        else
        {
            GameClearText.SetActive(false);
            gameclear.CloseGameClearMenu();
        }
    }

    public void Clear() // Game Clear
    {
        if (isClear && timer.LimitTime >= 0)
        {
            // TODO: Add UI or something. This needs more debate
            //SceneManager.LoadScene(1);
            gameclear.CallGameClearMenu();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void HandleHPBar()
    {
        playerHPBar.value = Mathf.Lerp(playerHPBar.value, playerLogic.hp / playerLogic.maxHp, Time.deltaTime * 10);
    }
}
