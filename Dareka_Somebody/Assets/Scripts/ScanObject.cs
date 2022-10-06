using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scan Objects that have layer named "whatisObject"
/// </summary>
public class ScanObject : MonoBehaviour
{
    /// <summary>
    /// manager is GameObject named GameManager, it will scan objects
    /// PressF is the text that is written "Press [F]"
    /// TalkWindow is the window which will be activated when PressF activate
    /// </summary>
    
    public GameManager manager;
    public GameObject PressF; //������ ���� press [F] ȭ�鿡 ���
    public GameObject TalkWindow; // ��ȭâ
    public float RaycastDistance = 2f;
    public LayerMask whatisObject;
    public FPSPlayer _Player;

    private Camera PlayerCam;
    private GameObject scanObject;
    //private GameObject temp_Object;
    private bool isTouched;
    
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
        isTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance, whatisObject);
        
        // If ray has been touched, It will execute the function "scan()" in "GameManager.cs"
        // 
        if (isTouched && _Player.flatVelocity.magnitude <0.1)
        {
            scanObject = hit.collider.gameObject;
            PressF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F) && scanObject != null)
            {
                manager.Scan(scanObject);
            }
        }
        else if (!isTouched )
        {
            //scanObject = temp_Object;
            PressF.SetActive(false);
            TalkWindow.SetActive(false);
        }
    }
}
