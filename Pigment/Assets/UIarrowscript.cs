using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIarrowscript : MonoBehaviour
{
    Transform thisTransform;

    float moveTimer = .5f;
    float moveCounter;
    float speed = .5f;

    Vector3 moveVector = new Vector3(0,1,0);


    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        moveCounter += Time.deltaTime;

        if(moveCounter >= moveTimer)
        {
            moveCounter = 0;

            if(speed > 0)
            {
                speed = -.5f;
            }

            else if(speed < 0)
            {
                speed = .5f;
            }
        }

        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
