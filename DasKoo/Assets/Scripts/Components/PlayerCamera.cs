using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivityX, mouseSensitivityY;
    public float minPitch, maxPitch;
    private float yaw, pitch;
    public Transform target;
    Vector3 cameraOffset;
    public float offsetDis;
    public float targetLookOffsetY;

    public float rotationSmoothTime;
    public Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    void Start()
    {
        cameraOffset = Vector3.Normalize(target.transform.position - transform.position);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityX;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityY;

        //limit pitch
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        
    }

    private void LateUpdate()
    {
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), 
                                      ref rotationSmoothVelocity, rotationSmoothTime);

        //Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = currentRotation;

        //rotate at camera's position
        //transform.position = offset * offsetDis;

        transform.position = (target.position + new Vector3(0, targetLookOffsetY)) - transform.forward * offsetDis;
    }
}
