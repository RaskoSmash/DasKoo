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
    public float cameraZoom, prevCameraZoom, maxCameraZoom, minCameraZoom;
    public float zoomMultiplier;
    Camera myCamera;

    public Vector3 upperLeft, upperRight, lowerLeft, lowerRight;
    public float pushCameraDistance;
    void Start()
    {
        //cameraOffset = Vector3.Normalize(target.transform.position - transform.position);
        myCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        cameraZoom = prevCameraZoom = offsetDis;
        if (target == null)
        {
            //i dont like this method
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        lowerRight = lowerLeft = upperRight = upperLeft = Vector3.zero;
    }

    void Update()
    {
        cameraZoom = prevCameraZoom;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityX;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityY;

        float tempZoom = Input.GetAxis("Mouse ScrollWheel");
        cameraZoom += -tempZoom * zoomMultiplier;
        if (cameraZoom > maxCameraZoom)
            cameraZoom = maxCameraZoom;
        else if (cameraZoom < minCameraZoom)
            cameraZoom = minCameraZoom;

        //limit pitch
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    private void LateUpdate()
    {
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw),
                                      ref rotationSmoothVelocity, rotationSmoothTime);
        //Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = currentRotation;

        //rotate at hotdogj's position
        //transform.position = offset * offsetDis;
        if (target != null)
        {
            //RaycastHit ray = CheckForCollision(target.position, transform.position);
            //if(ray.point != Vector3.zero)
            //{
            //    transform.position = new Vector3(ray.point.x, transform.position.y, ray.point.z);
            //}
            DoCollision();
            transform.position = (target.position + new Vector3(0, targetLookOffsetY)) - transform.forward * cameraZoom;
        }
        prevCameraZoom = cameraZoom;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private RaycastHit CheckForCollision(Vector3 from, Vector3 to)
    {
        RaycastHit wallHit = new RaycastHit();
        Debug.DrawLine(from, to, Color.cyan);
        if (Physics.Linecast(from, to, out wallHit))
        {
            Debug.DrawLine(wallHit.point, (wallHit.point + wallHit.normal), Color.red);
            return wallHit;
        }
        return new RaycastHit();
    }

    private void DoCollision()
    {
        lowerLeft = myCamera.ScreenToWorldPoint(new Vector3(0, 0, myCamera.nearClipPlane));
        upperLeft = myCamera.ScreenToWorldPoint(new Vector3(0, myCamera.pixelHeight, myCamera.nearClipPlane));
        lowerRight = myCamera.ScreenToWorldPoint(new Vector3(myCamera.pixelWidth, 0, myCamera.nearClipPlane));
        upperRight = myCamera.ScreenToWorldPoint(new Vector3(myCamera.pixelWidth, myCamera.pixelHeight, myCamera.nearClipPlane));

        RaycastHit ray = new RaycastHit();
        if(Physics.Linecast(target.position, transform.position, out ray))
        {
            //transform.position = transform.position + (transform.forward * pushCameraDistance);
            float disFromTarget = Vector3.Magnitude(target.position - transform.position);
            cameraZoom -= disFromTarget - ray.distance;
        }
        else if(Physics.Linecast(upperLeft, lowerLeft) || Physics.Linecast(lowerLeft, lowerRight) || Physics.Linecast(lowerRight, upperRight) || Physics.Linecast(upperRight, upperLeft))
        {
            cameraZoom -= pushCameraDistance;
        }
        Debug.DrawLine(target.position, transform.position, Color.cyan);
        Debug.DrawLine(upperLeft, lowerLeft, Color.green);
        Debug.DrawLine(lowerLeft, lowerRight, Color.green);
        Debug.DrawLine(lowerRight, upperRight, Color.green);
        Debug.DrawLine(upperRight, upperLeft, Color.green);
    }
    //private void DrawBounds()
    //{
    //    Vector3 upperLeft = Vector3.zero, upperRight = upperLeft, lowerLeft = upperLeft, lowerRight = upperLeft;
    //    upperLeft = myCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
    //    upperRight = myCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    //    Debug.DrawLine(upperLeft, upperRight, Color.green);
    //}
    //I have to be able to calculate a new camera zoom based on a new position
}
