using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("master", volume);
        mainMixer.GetFloat("master", out volume);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

    }

    public void Awake()
    {
        DontDestroyOnLoad(mainMixer);
    }
}
