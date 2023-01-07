using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider sensitivitySlider;

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("master", volume);
    }

    public void SetMouseSensitivity()
    {
        GetComponent<PlayerCamera>().ChangeMouseSensitivity(sensitivitySlider.value, sensitivitySlider.value);
    }
}
