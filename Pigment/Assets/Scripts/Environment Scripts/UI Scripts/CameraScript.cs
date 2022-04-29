using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{ 
    public float mouseSensitivity;

    public Transform cameraFocus;

    float xRotation;

    public int xRotationClampLower;
    public int xRotationClampHigher;

    private void Start()
    {
        mouseSensitivity = 200f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraFollowTarget();
    }

    private void CameraFollowTarget()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xRotationClampLower, xRotationClampHigher);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        cameraFocus.Rotate(Vector3.up * mouseX);
    }
}
