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
    public static bool isClear;

    public GameObject player;
    public GameObject canvas;

    FPSPlayer playerLogic;
    OniSpawner oniSpawner;
    public Oni oni;

    public int oniNum = 5;
    public static bool isHitOni = false;
    //public AudioClip groanClip;

    private void Start()
    {
        isClear = false;
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

        if (oniSpawner.deathOni >= oniNum)
        {
            isClear = true;
            Invoke("Clear", 2.0f);
        }
        else
        {
            if (!GameManager.isPaused)
            {
                GameClearText.SetActive(false);
                gameclear.CloseGameClearMenu();
            }
        }

        if (oni != null)
        {
            if (isHitOni)
            {
                PlayOniSound();
                //SoundManager.instance.SFXPlay("Groan", groanClip);
            }
        }
    }

    public void Clear() // Game Clear
    {
        if (isClear && timer.LimitTime >= 0)
        {
            gameclear.CallGameClearMenu();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void HandleHPBar()
    {
        playerHPBar.value = Mathf.Lerp(playerHPBar.value, playerLogic.hp / playerLogic.maxHp, Time.deltaTime * 10);
    }

    private void PlayOniSound()
    {
        if (!oni.audioSource.isPlaying)
        {
            oni.audioSource.Play();
            Debug.Log("Play");
            isHitOni = false;
        }
    }
}
