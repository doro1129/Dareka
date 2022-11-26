using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;

public class Dust : MonoBehaviour
{
    static private System.Random random = new System.Random();

    public GameObject[] dust_Prefab;
    public int dust_HP;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        dust_HP = random.Next(5, 10);
    }
}
