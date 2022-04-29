using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIpather : MonoBehaviour
{
    Transform thisTransform;

    float counter = 1f;

    float speed = 1;

    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        counter -= Time.deltaTime;

        if(counter < 0)
        {
            counter = 1f;

            if(speed == 1)
            {
                speed = -1;
            }

            else if(speed == -1)
            {
                speed = 1;
            }
        }

        transform.Translate(Vector3.forward * speed *  Time.deltaTime);        
    }
}
