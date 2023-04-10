using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WormController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 2.5f;

    // UI
    public TextMeshProUGUI countText;
    public TextMeshProUGUI objectiveText;

    // Pickups
    private AudioSource pickupSound;
    private int count;
    private bool hasObjective;

    void Start()
    {
        //Set Cursor to not be visible and lock its position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // get AudioSource component
		pickupSound = GetComponent<AudioSource>();

        // Set the count to zero 
		count = 0;
		SetCountText ();
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

    void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			// Play pickup sound.
			pickupSound.Play();
		}
	} // end OnTriggerEnter

    void SetCountText()
	{
		countText.text = "Collectables: " + count.ToString();
	} // end SetCountText
} // end WormController

