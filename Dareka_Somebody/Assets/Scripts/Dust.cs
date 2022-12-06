using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;

public class Dust : MonoBehaviour
{
    static private System.Random random = new System.Random();
    public int dust_HP;

    private void Start()
    {
        Init();
    }

    // Initialize HP of dust objects
    public void Init()
    {
        dust_HP = random.Next(5, 10);
    }
}
