using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    Transform thisTransform;
    Vector3 startTransform;

    float speed = 3f;

    bool holdingMushroom; 

    protected virtual void Start()
    {
        thisTransform = GetComponent<Transform>();

        startTransform = thisTransform.position;
    }

    public void ToggleHoldingOn()
    {
        holdingMushroom = true;
    }

    public void ToggleHoldingOff()
    {
        holdingMushroom = false;
    }

    private void Update()
    {
        if (holdingMushroom)
        {
            if (thisTransform.position.y <= 5.5 && thisTransform.position.x > -4)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            else if (thisTransform.position.y >= 5.5 && thisTransform.position.x > -4)
            {
                transform.Translate(Vector3.right * -speed * Time.deltaTime);
            }

            else if (thisTransform.position.x <= -4 && transform.position.y > 2.7f)
            {
                transform.Translate(Vector3.up * -speed * Time.deltaTime);
            }

            else if (transform.position.y <= 2.7f && thisTransform.position.x <= -4)
            {
                thisTransform.position = startTransform;
            }
        }

        else
        {
            thisTransform.position = startTransform;
        }
    }
}
