using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will sense the rotation value of axis X and Y
/// The camera shows the view of player
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    /// <summary>
    /// X and Y sensitivity
    /// Sensor X will sense the horizontal rotation of player and camera
    /// Sensor Y will sense the vertical rotation of camera
    /// </summary>
    public float sensitivityX;
    public float sensitivityY;
    
    /// <summary>
    /// orientation will store the direction where the player facing
    /// </summary>
    public Transform orientation;
    public GameObject player;

    /// <summary>
    /// X and Y rotation of player's camera
    /// </summary>
    private float xRotation;
    private float yRotation;
    private float mouseX;
    private float mouseY;
    
    // manager is defined To invoke the function 'isScan'
    public GameManager manager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // If objects are scanned, Player will not be rotate the camera.
        if (manager.isScan == true)
        {
            mouseX = 0;
            mouseY = 0;
        }
        else
        {
            // get mouse input
            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate camera and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

            player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
