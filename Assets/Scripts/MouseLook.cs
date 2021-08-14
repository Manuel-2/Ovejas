using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] float sensitivity;
    [SerializeField] Transform playerBody;

    Vector2 mouseMovement;
    float xRotation;

    private bool canRotate;


    private void Awake()
    {
        gameIsPaused = false;
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


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void OnChangeMouseSensitivity(float value)
    {
        sensitivity = value;
    }


    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canRotate = true;

        //stop the game
        Time.timeScale = 1f;
        //enable canvas
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        canRotate = false;

        //stop the game
        Time.timeScale = 0f;
        //enable canvas
        pauseMenu.SetActive(true);
        gameIsPaused = true;
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
