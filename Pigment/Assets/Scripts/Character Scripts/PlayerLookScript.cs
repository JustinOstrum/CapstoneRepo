using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookScript : MonoBehaviour
{
    [SerializeField]
    private float xSensitivity;

    [SerializeField]
    private float ySensitivity;

    public Camera cam;

    public Transform defaultCameraPOS;

    public Vector3 cameraInteractPOS;
    public Quaternion cameraInteractROT;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    public CursorLockMode cursorLock;

    private void Start()
    {
        cursorLock = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        PlayerCameraInput();
               
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);        
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    void PlayerCameraInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * xSensitivity * multiplier;
        xRotation -= mouseY * ySensitivity * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
