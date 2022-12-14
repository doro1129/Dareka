using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBeans : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    private float lifeTime = 2f;
    public float pelletFireVelocity = 1;
    public GameObject pellet;
    public Transform BarrelExit;
    public GameObject armRoot;

    List<Quaternion> pellets;
    public AudioClip throwBeansClip;

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
            if (!GameManager.isPaused)
            {
                PreFire();
            }
        }
    }

    void PreFire()
    {
        armRoot.transform.Rotate(new Vector3(0f, 0f, -30f), Space.Self);
        
        Invoke("Fire", 0.1f);
    }

    void Fire()
    {
        SoundManager.instance.SFXPlay("Throw Beans", throwBeansClip);

        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject spawnPellet = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            Destroy(spawnPellet, lifeTime);
            spawnPellet.transform.rotation = Quaternion.RotateTowards(spawnPellet.transform.rotation, pellets[i], spreadAngle);
            spawnPellet.GetComponent<Rigidbody>().AddForce(spawnPellet.transform.right * pelletFireVelocity);
            spawnPellet.GetComponent<Rigidbody>().AddForce(spawnPellet.transform.up * 10);
        }

        armRoot.transform.Rotate(new Vector3(0f, 0f, 30f), Space.Self);
    }    
}
