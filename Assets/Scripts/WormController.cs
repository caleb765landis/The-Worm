using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 5.0f;

    private Vector2 lastMousePosition;
    private bool mouseIsMoving = false;

    void Start()
    {
        lastMousePosition = Input.mousePosition;

        //Set Cursor to not be visible and lock its position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 currentMousePosition = Input.mousePosition;

        // Right
        if (Input.GetAxis("Mouse Y") > 0)
        {
            Vector3 rotationToAdd = new Vector3(0, turnSpeed, 0);
            transform.Rotate(rotationToAdd);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        // left
        if (Input.GetAxis("Mouse Y") < 0)
        {
            Vector3 rotationToAdd = new Vector3(0, -turnSpeed, 0);
            transform.Rotate(rotationToAdd);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        lastMousePosition = currentMousePosition;
    } // end Update
} // end WormController

