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
        // StartCoroutine(MoveCamera());
        // Vector3 flippedOffset = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 30), 0.125f);
        flippedOffset = new Vector3(0, 0, -30);
        
    }

    // IEnumerator MoveCamera()
    // {
    //     Vector3 flippedOffset = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 30), 0.125f);
    // }
}

