using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryScript : MonoBehaviour
{
    //This script allows for objects to reference the transform of the Carry Object

    Transform carryTransform;

    public bool isCarrying;

    private void Start()
    {
        carryTransform = GetComponent<Transform>();
        isCarrying = false;
    }
}