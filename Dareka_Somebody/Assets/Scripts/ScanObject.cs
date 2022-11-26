using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scan Objects that have layer named "Dust"
/// </summary>
public class ScanObject : MonoBehaviour
{
    /// <summary>
    /// manager is GameObject named GameManager, it will scan objects
    /// PressF is the text that is written "Press [F]"
    /// TalkWindow is the window which will be activated when PressF activate
    /// </summary>
    public GameObject PressSpace; // press [Space]
    public GameObject PressF; // press [F]
    public GameObject TalkWindow;
    public GameObject dust_HP;
    public Text dust_count1;
    public Text dust_count2;
    
    public LayerMask isObject;
    public LayerMask Dust;
    public AudioClip clip;
    public GameManager manager;
    public FPSPlayer _Player;
    public float RaycastDistance = 2f;

    private Dust dust;
    private Camera PlayerCam;
    private GameObject scanObject;
    private GameObject scanDust;
    private bool ObjectisTouched;
    private bool DustisTouched;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

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

        ObjectisTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance, isObject);
        // If ray has touched objects, It will execute the function "scan()" in "GameManager.cs"
        if (ObjectisTouched && _Player.flatVelocity.magnitude < 0.1)
        {
            scanObject = hit.collider.gameObject;
            PressSpace.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            {
                manager.Scan(scanObject);
                //TalkWindow.SetActive(true);
                //SoundManager.instance.SFXPlay("Investigate", clip);
            }
        }
        else if (!ObjectisTouched)
        {
            PressSpace.SetActive(false);
            TalkWindow.SetActive(false);
        }


        DustisTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance, Dust);
        // If ray has touched dust, It will execute the function "Clean()" in "GameManager.cs"
        if (DustisTouched)
        {
            scanDust = hit.collider.gameObject;
            PressF.SetActive(true);
            dust_HP.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.F) && scanDust != null)
            {
                dust = scanDust.GetComponent<Dust>();
                dust.dust_HP--;
                dust_count2.text = dust.dust_HP.ToString() + " 번";
                if (dust.dust_HP == 0)
                {
                    Destroy(scanDust);
                    manager.GetDustScore();
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
}
