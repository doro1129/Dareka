using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveScan : MonoBehaviour
{
    // Gameobjects in canvas
    // Press- objects are text when player's ray has touched objects or dusts
    // TalkWindow is the window which will be activated when PressSpace activate
    // dust_counts are in the dust_HP and they are the text that show how many times player has to press [f]
    public GameObject PressSpace; // press [Space]
    public GameObject TalkWindow;
    public GameObject EndingCanvas;

    // manager is GameObject named GameManager, it will scan objects
    // FPSPlayer is player, it will check the speed or velocity of player
    public GameManager manager;
    public FPSPlayer _Player;
    public LayerMask GraveStone;
    //public AudioClip clip;
    public float RaycastDistance = 2f;

    public Text EndingDialogue_Text;
    private string[] EndingDialogue_String;
    private int Endingdialogue_count = 0;

    private Camera PlayerCam;
    private GameObject scanObject;
    private bool GraveTouched;
    //private bool isScanned = false;

    //AudioSource audioSRC;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        PlayerCam = Camera.main;
        //audioSRC = GetComponent<AudioSource>();
        Set_Dialogue();
        EndingCanvas.SetActive(false);
    }

    private void Update()
    {
        // Raycast will follow the direction the player sees, and It will check the collision with objects. 
        Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); // Center of display
        Vector3 rayDirection = PlayerCam.transform.forward;
        RaycastHit hit;

        // If ray has touched objects, It will execute the function "scan()" in "GameManager.cs"
        GraveTouched = Physics.Raycast(rayOrigin, rayDirection, out hit, RaycastDistance * 1.5f, GraveStone);
        if (GraveTouched && _Player.flatVelocity.magnitude < 0.1)
        {
            scanObject = hit.collider.gameObject;
            PressSpace.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            {
                Talking();
                manager.isScan = true;
                PressSpace.SetActive(false);
                //SoundManager.instance.SFXPlay("Investigate", clip);
            }
            //manager.isScan = false;
        }
        else if (!GraveTouched)
        {
            PressSpace.SetActive(false);
            TalkWindow.SetActive(false);
        }

        if (Endingdialogue_count == 4)
        {
            //sceneControl.OnclickStageScene();
            SceneManager.LoadScene(0);
            //GameManager.isPaused = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1f;
            Endingdialogue_count = 0;
        }

    }

    public void Talking()
    {
        EndingCanvas.SetActive(true);
        if (Endingdialogue_count <= 2)
        {
            EndingDialogue_Text.text = EndingDialogue_String[Endingdialogue_count];
            Endingdialogue_count++;
        }
        else if (Endingdialogue_count == 3)
        {
            EndingDialogue_Text.text = EndingDialogue_String[Endingdialogue_count - 1];
            Endingdialogue_count++;
        }
    }

    public void Set_Dialogue()
    {
        EndingDialogue_String = new string[3]
        {
        "엄마... ",
        "오랜만이야.",
        "보고싶었어..."
        };
    }

}
