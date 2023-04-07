using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 2.5f;

    void Start()
    {
        //Set Cursor to not be visible and lock its position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Wiggle Right
        if (Input.GetAxis("Mouse Y") > 0)
        {
            Vector3 rotationToAdd = new Vector3(0, turnSpeed, 0);
            transform.Rotate(rotationToAdd);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        // Wiggle Left
        if (Input.GetAxis("Mouse Y") < 0)
        {
            Vector3 rotationToAdd = new Vector3(0, -turnSpeed, 0);
            transform.Rotate(rotationToAdd);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    } // end Update
} // end WormController

