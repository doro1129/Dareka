using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DustSpawn : MonoBehaviour
{
    public Dust dust;
    public Transform[] dust_SpawnPoint = new Transform[6];

    private int[] dust_Position = new int[6]; // Position array of dust

    static private System.Random random = new System.Random();
    private int dustpoint; // spawn point of dust prefab, it will be determined at random
    public GameObject dustclone;

    public void Start()
    {
        Spawn();
        dustclone.GetComponent<Dust>().Init();
    }

    public void Spawn()
    {
        for (int i = 0; i < 6; i++)
        {
            dustpoint = random.Next(0, 9);
            bool duplicate = false;
            if (i > 0 && i < 6)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (dust_Position[j] == dustpoint)
                    {
                        duplicate = true;
                    }
                }
            }
            if (duplicate)
            {
                --i;
            }
            else
            {
                dust_Position[i] = dustpoint;
            }
        }
        for(int i =0; i<dust_SpawnPoint.Length - 4; i++)
        {
            Vector3 RandomSpawnPosition = dust_SpawnPoint[dust_Position[i]].position; //dustpoint는 0부터 9까지만 주면 됨
            dustclone = Instantiate(dust.dust_Prefab[i], RandomSpawnPosition, Quaternion.identity) as GameObject;
        }
    }
}
