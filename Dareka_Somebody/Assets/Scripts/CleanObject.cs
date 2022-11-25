using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanObject : MonoBehaviour
{
    /// <summary>
    /// manager is GameObject named GameManager, it will scan objects
    /// PressF is the text that is written "Press [F]"
    /// TalkWindow is the window which will be activated when PressF activate
    /// </summary>
    //public GameManager manager;
    public Dust dust;
    public GameObject PressF; //?????? ???? press [F] ?????? ????
    public LayerMask Dust;
    public float RaycastDistance = 2f;

    private Camera PlayerCam;
    private GameObject scanObject;

    //private GameObject temp_Object;
    private bool isTouched;

    //public AudioClip clip;

    /*private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }*/

    private void Start()
    {
        PlayerCam = Camera.main;
    }

    private void Update()
    {
        // Raycast will follow the direction the player sees, and It will check the collision with objects. 
        Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); // Center of display
        Vector3 rayDirection = PlayerCam.transform.forward;
        RaycastHit hit;
        isTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance, Dust);

        // If ray has been touched, It will execute the function "scan()" in "GameManager.cs"
        // 
        if (isTouched)
        {
            scanObject = hit.collider.gameObject;
            PressF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F) && scanObject != null)
            {
                PressF.SetActive(false);
                /*if (dust.inc_count() == dust.dust_HP)
                {
                    dust.Remove_dust();
                }*/
                //SoundManager.instance.SFXPlay("Investigate", clip);
            }
        }
        else if (!isTouched)
        {
            //scanObject = temp_Object;
            PressF.SetActive(false);
        }
    }
}
