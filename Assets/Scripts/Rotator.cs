using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotationSpeed = 0.5f;

	void Update () 
	{
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime * rotationSpeed);
	}
}	

