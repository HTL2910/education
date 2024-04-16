using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_HeroController : MonoBehaviour
{
    [Tooltip("Character settings (rigid body)")]
    public float MoveSpeed = 30f, JumpForce = 200f, Sensitivity = 70f;
    bool jumpFlag = true; // to jump from surface only

    CharacterController character;
    Rigidbody rb;
    Vector3 moveVector;

    Transform Cam;
    float yRotation;
    public AudioClip steps;
    public AudioSource sources;
    void Start()
    {
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Cam = Camera.main.GetComponent<Transform>();
        sources = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked; // freeze cursor on screen centre
        Cursor.visible = false; // invisible cursor
        sources.clip = steps;
    }

    void Update()
    {
       
        float xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        float ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;
        transform.Rotate(Vector3.up * xmouse);
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        Cam.localRotation = Quaternion.Euler(yRotation, 0, 0);


        if (Input.GetButtonDown("Jump") && jumpFlag)
        {
            rb.AddForce(transform.up * JumpForce);
        }

    
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            if (!sources.isPlaying) 
            {
                sources.Play(); 
            }
        }
        else
        {
            sources.Stop(); 
        }
    }


    void FixedUpdate()
    {
 
        moveVector = transform.forward * MoveSpeed * Input.GetAxis("Vertical") +
            transform.right * MoveSpeed * Input.GetAxis("Horizontal") +
            transform.up * rb.velocity.y;
        rb.velocity = moveVector;

        
    }
    
    private void OnTriggerStay(Collider other)
    {
        jumpFlag = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        jumpFlag = false;
    }

}
