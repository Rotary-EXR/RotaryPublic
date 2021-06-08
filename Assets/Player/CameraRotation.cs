using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
public class CameraRotation : NetworkBehaviour
{
    public float sensitivity = 10f;
    public float maxYAngle = 60f;
    private Vector2 currentRotation;
    public GameObject Playercam;
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) { return; };
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        Playercam.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }
}
