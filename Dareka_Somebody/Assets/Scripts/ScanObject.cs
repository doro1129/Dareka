using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameManager manager;
    public FPSPlayer _Player;
    public Dust dust;
    public GameObject PressSpace; // press [Space]
    public GameObject PressF; // press [F]
    public GameObject TalkWindow;
    public float RaycastDistance = 2f;
    public LayerMask whatisObject;
    public LayerMask Dust;
    public AudioClip clip;

    private Camera PlayerCam;
    private GameObject scanObject;
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
        ObjectisTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance, whatisObject);
        DustisTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance, Dust);

        // If ray has touched objects, It will execute the function "scan()" in "GameManager.cs"
        if (ObjectisTouched && _Player.flatVelocity.magnitude < 0.1)
        {
            scanObject = hit.collider.gameObject;
            PressSpace.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            {
                manager.Scan(scanObject);
                //PressSpace.SetActive(false); // 어차피 안됨
                //SoundManager.instance.SFXPlay("Investigate", clip);
            }
        }
        else if (!ObjectisTouched)
        {
            //scanObject = temp_Object;
            PressSpace.SetActive(false);
            TalkWindow.SetActive(false);
        }

        // If ray has touched dust, It will execute the function "Clean()" in "GameManager.cs"
        if (DustisTouched)
        {
            scanObject = hit.collider.gameObject;
            PressF.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.F) && scanObject != null)
            {
                manager.Clean(scanObject);
                //SoundManager.instance.SFXPlay("Investigate", clip);
            }
        }
        else if (!DustisTouched)
        {
            //scanObject = temp_Object;
            PressF.SetActive(false);
            TalkWindow.SetActive(false);
        }
    }
}
