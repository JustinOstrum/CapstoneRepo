using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    private float SceneWidth;
    private Vector3 PressPoint;
    private Quaternion StartRotation;

    private void Start()
    {
        SceneWidth = Screen.width;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PressPoint = Input.mousePosition;
            StartRotation = transform.rotation;
        }

    else if (Input.GetMouseButton(0))
        {
            float CurrentDistanceBetweenMousePosition = (Input.mousePosition - PressPoint).x;

            transform.rotation = StartRotation * Quaternion.Euler(Vector3.up * (CurrentDistanceBetweenMousePosition / SceneWidth) * 369);
        }
    }
}
