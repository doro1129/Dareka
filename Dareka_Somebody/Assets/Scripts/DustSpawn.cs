using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DustSpawn : MonoBehaviour
{
    // dust_Prefab is the prefab of dust
    public GameObject dust_Prefab;
    // dust_SpawnPoint is the array of dust's Transform
    public Transform[] dust_SpawnPoint = new Transform[9];

    static private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
    private GameObject dustclone;
    private int[] dust_Position = new int[6]; // Position array of dust
    private int dustpoint; // spawn point of dust prefab, it will be determined at random
    
    private void Start()
    {
        Spawn();
    }

    // Spawn 5 of dusts randomly without duplication
    public void Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            dustpoint = random.Next(0, 9);
            bool duplicate = false;
            if (i > 0 && i < 5)
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
        for(int i =0; i<dust_SpawnPoint.Length-4; i++)
        {
            Vector3 RandomSpawnPosition = dust_SpawnPoint[dust_Position[i]].position;
            dustclone = Instantiate(dust_Prefab, RandomSpawnPosition, Quaternion.identity) as GameObject;
        }
    }
}
