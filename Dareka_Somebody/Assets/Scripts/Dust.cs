using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dust : MonoBehaviour
{
    static private System.Random random = new System.Random();

    public GameObject[] dust_Prefab;
    public int dust_HP;

    private void Start()
    {
        Set_dustHP();
        Init();
    }

    public void Init()
    {
        dust_HP = random.Next(5, 10);
    }

    public void Set_dustHP()
    {
        dust_HP = random.Next(5, 10);
    }

    public int Get_dustHP()
    {
        return dust_HP;
    }

    public void Dec_dustHP()
    {
        dust_HP--;
    }

    public void Remove_dust()
    {
        for (int i = 0; i < dust_Prefab.Length; i++)
        {
            if (dust_HP <= 0)
            {
                Destroy(dust_Prefab[i]);
            }
        }
    }
}
