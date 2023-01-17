using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class CopyMouseSensitive : MonoBehaviour
{
    public float copyValue;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("mouse");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
