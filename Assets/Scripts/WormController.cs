using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WormController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 2.5f;
    public float lerpDuration = 0.5f;
    public bool rotating;

    public GameObject wormAndCamera;
    public GameObject _camera;

    // UI
    public TextMeshProUGUI countText;
    public TextMeshProUGUI objectiveText;

    // Pickups
    private AudioSource pickupSound;
    private int count;
    public bool hasObjective = false;

    void Start()
    {
        // wormAndCamera.transform.position = new Vector3(490,0,927);

        //Set Cursor to not be visible and lock its position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // get AudioSource component
		pickupSound = GetComponent<AudioSource>();

        // Set the count to zero 
		count = 0;
		SetCountText ();

        // Set objective
        objectiveText.text = "Objective: Your neighbor asked you for some sugar. Go find them some!";
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

        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Objective"))
		{
			other.gameObject.SetActive (false);

            // Rotate player and camera
            //StartCoroutine(RotateWormAndCamera());
            wormAndCamera.transform.Rotate(new Vector3(0, 180, 0));
            Camera.main.GetComponent<CameraController>().RotateAroundWorm();
            transform.position = new Vector3(500, 0, 590);
            
            objectiveText.text = "Objective: Bring the sugar back to your neighbor!";

            hasObjective = true;

			// Play pickup sound.
			pickupSound.Play();
		}
	} // end OnTriggerEnter

    void SetCountText()
	{
		countText.text = "Collectables: " + count.ToString();
	} // end SetCountText

    IEnumerator RotateWormAndCamera()
    {
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = wormAndCamera.transform.rotation;
        Quaternion targetRotation = wormAndCamera.transform.rotation * Quaternion.Euler(0, 180, 0);
        while (timeElapsed < lerpDuration)
        {
            wormAndCamera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wormAndCamera.transform.rotation = targetRotation;
        rotating = false;
    }
} // end WormController

