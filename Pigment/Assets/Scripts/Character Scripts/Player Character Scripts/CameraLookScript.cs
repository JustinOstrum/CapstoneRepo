using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookScript : MonoBehaviour
{
    public float sppedH = 2.0f;
    public float sppedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Update()
    {
        yaw += sppedH * Input.GetAxis("Mouse X");
        pitch -= sppedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -90f, 90f);
        pitch = Mathf.Clamp(pitch, -60f, 60f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
