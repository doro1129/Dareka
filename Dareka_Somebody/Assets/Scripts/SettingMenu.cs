using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider sensitivitySlider;

    private float mainVolume;

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("master", volume);
        mainVolume = volume;
    }

    public void SetMouseSensitivity()
    {
        GetComponent<PlayerCamera>().ChangeMouseSensitivity(sensitivitySlider.value, sensitivitySlider.value);
    }

    /*public void Awake()
    {
        DontDestroyOnLoad(mainVolume);
    }*/

    public void Update()
    {
        Debug.Log(mainVolume);
    }
}
