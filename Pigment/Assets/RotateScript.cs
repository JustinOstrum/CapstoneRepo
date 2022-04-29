using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Transform rotateOBJ;

    public float xSpread;
    public float zSpread;
    public float yOffset;

    public float rotSpeed;
    public bool rotateClockwise;

    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        Rotate();
        transform.LookAt(rotateOBJ);
    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + rotateOBJ.position;
        }

        else
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + rotateOBJ.position;
        }
    }
}
