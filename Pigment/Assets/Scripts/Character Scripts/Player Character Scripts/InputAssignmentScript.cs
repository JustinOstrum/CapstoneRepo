using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAssignmentScript : MonoBehaviour
{
    //(x,y) vector that captures the directional keys
    public Vector2 InputVector { get; private set; }

    //(x,y,z) vector that captures the mousePosition
    public Vector3 MousePosition { get; private set; }

    float h;
    float v;

    private void Update()
    {
        h = Input.GetAxis("Horizontal"); //uses Unity's input system to get the -1 to 1 for the "horizontal" axis (left, right)
        v = Input.GetAxis("Vertical"); //uses Unity's input system to get the -1 to 1 for the "vertical" axis (down, up)
        
        MousePosition = Input.mousePosition; //calculates the mouseposition based on the input system
    }

    private void FixedUpdate()
    {
        InputVector = new Vector2(h, v); //calculates InputVector based on what keys are pressed. eg. left, up = -1, 1
    }
}
