using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scan Objects that have layer named "Dust"
/// </summary>
public class ScanObject : MonoBehaviour
{
    // Gameobjects in canvas
    // Press- objects are text when player's ray has touched objects or dusts
    // TalkWindow is the window which will be activated when PressSpace activate
    // dust_counts are in the dust_HP and they are the text that show how many times player has to press [f]
    public GameObject PressSpace; // press [Space]
    public GameObject PressF; // press [F]
    public GameObject TalkWindow;
    public GameObject dust_HP; // parent of dust_count1 and dust_count2
    public Text dust_count;

    // manager is GameObject named GameManager, it will scan objects
    // FPSPlayer is player, it will check the speed or velocity of player
    public GameManager manager;
    public CleaningManager c_manager;
    public FPSPlayer _Player;
    public LayerMask isObject;
    public LayerMask Dust;
    //public AudioClip clip;
    public float RaycastDistance = 2f;

    private Dust dust;
    private Camera PlayerCam;
    private GameObject scanObject;
    private GameObject scanDust;
    private bool ObjectisTouched;
    private bool DustisTouched;

    //AudioSource audioSRC;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        PlayerCam = Camera.main;
        //audioSRC = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Raycast will follow the direction the player sees, and It will check the collision with objects. 
        Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); // Center of display
        Vector3 rayDirection = PlayerCam.transform.forward;
        RaycastHit hit;

        // If ray has touched objects, It will execute the function "scan()" in "GameManager.cs"
        ObjectisTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance * 1.5f, isObject);
        if (ObjectisTouched && _Player.flatVelocity.magnitude < 0.1)
        {
            scanObject = hit.collider.gameObject;
            PressSpace.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            {
                manager.Scan(scanObject);
                PressSpace.SetActive(false);
                SoundManager.instance.SFXPlay("Investigate", clip);
            }
        }
        else if (!ObjectisTouched)
        {
            PressSpace.SetActive(false);
            TalkWindow.SetActive(false);
        }

        // If ray has touched dust and Presses F, It will handle the HP of dusts and outputs UI on display
        DustisTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance * 1.5f, Dust);
        if (DustisTouched)
        {
            scanDust = hit.collider.gameObject;
            PressF.SetActive(true);
            dust_HP.SetActive(true);
            dust = scanDust.GetComponent<Dust>();
            dust_count.text = "앞으로   " + dust.dust_HP.ToString() + "  번";
            if (Input.GetKeyDown(KeyCode.F) && scanDust != null)
            {
                //Blooming();
                dust.dust_HP--;
                if (dust.dust_HP == 0)
                {
                    Destroy(scanDust);
                    c_manager.GetDustScore();
                }
                //SoundManager.instance.SFXPlay("Investigate", clip); // TODO: Need to chage "Investigate" to "Cleaning" sound like broom.
            }
        }
        else if (!DustisTouched)
        {
            PressF.SetActive(false);
            dust_HP.SetActive(false);
        }
    }
    /*private void Blooming()
    {

        if (!audioSRC.isPlaying)
        {
            audioSRC.Play();
        }
        else
        {
            audioSRC.Stop();
        }
    }*/
}
