using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float originalSpeedMovement;
    [SerializeField] float airSpeedMovement;
    public float pillowSpeedModifier;
    float speedMovement;

    [SerializeField] float jumpHeight;
    [SerializeField] float gravity = -9.81f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance;
    [SerializeField] LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {

        speedMovement = originalSpeedMovement;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        
        if(isGrounded && velocity.y < 0){
            velocity.y = -0.5f;
            speedMovement = originalSpeedMovement;
        }

        

        Vector3 movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        //aplica el movimiento
        controller.Move(movement * (speedMovement * pillowSpeedModifier) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            speedMovement = airSpeedMovement;
        }

        //aplica la gravedad
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);

    }
}
