using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Vector3 flippedOffset = new Vector3(0, 0, 0);

    private Vector3 offset;

    public float lerpDuration = 0.5f;
    public bool rotating;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset + flippedOffset;

    }

    public void RotateAroundWorm()
    {
        flippedOffset = new Vector3(0, 0, -30);
        transform.position = new Vector3(500, 0, 590) + offset + flippedOffset;
        
    }
}

