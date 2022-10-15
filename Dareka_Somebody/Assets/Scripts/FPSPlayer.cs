using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This class is a script that detects and controls the movement of the player.
/// </summary>
public class FPSPlayer : MonoBehaviour
{
    /// <summary>
    /// orientation will store the direction where the player facing
    /// </summary>
    public Transform orientation;
    public GameManager manager;
    private Rigidbody rigidbody1;

    // Player's moddable numerical values of movement like waliking speed, jump force
    [Header("Movement")]
    /// <summary>
    /// Player's speed when player walk and run
    /// </summary>
    public float MoveSpeed = 10;
    public float RunSpeed = 20;

    /// <summary>
    /// Resistance of ground when moving
    /// The higher the value, the stronger the resistance of the ground on which the player walks.
    /// </summary>
    public float GroundDrag = 10f;

    /// <summary>
    /// AirMultiplier is the value that decreases the speed when player is floating
    /// </summary>
    public float AirMultiplier =1.0f;

    //To check if player is on the ground
    [Header("Ground Check")]
    /// <summary>
    /// To check the layer which is named 'what is ground'
    /// </summary>
    public LayerMask ground;

    /// <summary>
    /// It will 'True' when player is on ground or false when floating
    /// </summary>
    public bool grounded;
    public float RaycastDistance = 0.9f;
    public Vector3 flatVelocity;

    private Vector3 moveDirection;
    private float horizontalInput;
    private float verticalInput;

    Animator animator;
    AudioSource audioSrc;
    bool isMoving = false;

    private void Start()
    {
        rigidbody1 = GetComponent<Rigidbody>();
        rigidbody1.freezeRotation = true;   // not to fall down

        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check if it is attaching at the ground by using raycast as type of boolean
        // If objects are scanned, Player will not be able to move.
        grounded = Physics.Raycast(transform.position + new Vector3(0, 0.8f, 0), Vector3.down, RaycastDistance, ground);
        //Debug.DrawRay(transform.position+new Vector3(0,1f,0), Vector3.down, Color.red,RaycastDistance+0.2f);
        MyInput();
        SpeedControl();

        // Handle drag
        if (grounded)
        {
            rigidbody1.drag = GroundDrag;
        }
        else
        {
            rigidbody1.drag = 1;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// Detect the value of Horizontal and Vertical input
    /// If press the 'jump key(space)' player will jump
    /// </summary>
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Calculate the movement direction
    /// When on the ground or in the air, it gives the proper force for the situation.
    /// </summary>
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //d
        if (grounded)
        {
            if (manager.isScan == false)
            {
                var currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : MoveSpeed;
                rigidbody1.AddForce(moveDirection.normalized * currentSpeed * 10f, ForceMode.Force);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetFloat("Horizontal", horizontalInput);
                    animator.SetFloat("Vertical", verticalInput);
                }
                else
                {
                    animator.SetFloat("Horizontal", horizontalInput * 0.1f);
                    animator.SetFloat("Vertical", verticalInput * 0.1f);
                }

                PlayWalkSound();
            }
            else if (manager.isScan == true)
            {
                var currentSpeed = MoveSpeed;
                rigidbody1.AddForce(moveDirection.normalized * currentSpeed * 0f, ForceMode.Force);
            }
        }

        //in air
        else
        {
            rigidbody1.AddForce(moveDirection.normalized * MoveSpeed * 10f * AirMultiplier, ForceMode.Force);
        }
    }

    private void PlayWalkSound()
    {
        if (horizontalInput != 0f | verticalInput != 0f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
        {
            audioSrc.Stop();
        }

    }

    /// <summary>
    /// Manually limit the speed of the player
    /// </summary>
    public void SpeedControl()
    {
        flatVelocity = new Vector3(rigidbody1.velocity.x, 0f, rigidbody1.velocity.z);
        
        //limit velocity if needed
        if (flatVelocity.magnitude > MoveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * MoveSpeed;
            rigidbody1.velocity = new Vector3(limitedVelocity.x, rigidbody1.velocity.y, limitedVelocity.z);
        }
    }
}
