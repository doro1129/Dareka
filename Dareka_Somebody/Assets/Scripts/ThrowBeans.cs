using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBeans : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVelocity;
    public GameObject pellet;
    public Transform BarrelExit;
    List<Quaternion> pellets;

    private void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        for(int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject spawnPellet = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            spawnPellet.transform.rotation = Quaternion.RotateTowards(spawnPellet.transform.rotation, pellets[i], spreadAngle);
            spawnPellet.GetComponent<Rigidbody>().AddForce(spawnPellet.transform.right * pelletFireVelocity);
        }
    }    
}
