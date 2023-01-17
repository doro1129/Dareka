using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMouse : MonoBehaviour
{
    public Slider mouseSensitivity;

    private void Awake()
    {
        mouseSensitivity.value = GameObject.Find("Mouse Value").GetComponent<CopyMouseSensitive>().copyValue;
    }

    public void SetMouseSensitivity()
    {
        /*GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>().sensitivityX = mouseSensitivity.value;
        GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>().sensitivityY = mouseSensitivity.value;*/

        GameObject[] objs = GameObject.FindGameObjectsWithTag("mouse");
        CopyMouseSensitive copyMouseSensitive = objs[0].GetComponent<CopyMouseSensitive>();
        copyMouseSensitive.copyValue = mouseSensitivity.value;

        GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>().sensitivityX = copyMouseSensitive.copyValue;
        GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>().sensitivityY = copyMouseSensitive.copyValue;
    }
}