﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] Transform playerBody;

    Vector2 mouseMovement;
    float xRotation;

    private bool canRotate;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            mouseMovement.x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            mouseMovement.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= mouseMovement.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseMovement.x);
        }
        
    }

    public void DeactivateCameraMovement()
    {
        canRotate = false;
    }

    public void ReactivateCameraMovement()
    {
        canRotate = true;
    }
}
