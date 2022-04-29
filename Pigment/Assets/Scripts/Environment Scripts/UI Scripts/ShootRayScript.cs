using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRayScript : MonoBehaviour
{
    public Transform blueTarget;

    public Transform redTarget;

    public Transform yellowTarget;

    public Vector3 force;

    public float forceAmp;

    Vector3 direction;

    public LayerMask mask;

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        RaycastHit hit;

    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (Physics.Raycast(ray, out hit, 100f, mask))
    //        {
    //            if (hit.collider.gameObject.CompareTag("RedFruit"))
    //            {
    //                direction = (redTarget.transform.position - hit.collider.gameObject.transform.position).normalized;
    //                hit.rigidbody.AddForceAtPosition(direction * forceAmp + force, hit.point);
    //            }

    //            if (hit.collider.gameObject.CompareTag("BlueFruit"))
    //            {
    //                direction = (blueTarget.transform.position - hit.collider.gameObject.transform.position).normalized;
    //                hit.rigidbody.AddForceAtPosition(direction * forceAmp + force, hit.point);
    //            }

    //            if (hit.collider.gameObject.CompareTag("YellowFruit"))
    //            {
    //                direction = (yellowTarget.transform.position - hit.collider.gameObject.transform.position).normalized;
    //                hit.rigidbody.AddForceAtPosition(direction * forceAmp + force, hit.point);
    //            }

    //            Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.green);
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                if (hit.collider.gameObject.CompareTag("RedFruit"))
                {
                    direction = (redTarget.transform.position - hit.collider.gameObject.transform.position).normalized;
                    hit.rigidbody.AddForceAtPosition(direction * forceAmp + force, hit.point);
                }

                if (hit.collider.gameObject.CompareTag("BlueFruit"))
                {
                    direction = (blueTarget.transform.position - hit.collider.gameObject.transform.position).normalized;
                    hit.rigidbody.AddForceAtPosition(direction * forceAmp + force, hit.point);
                }

                if (hit.collider.gameObject.CompareTag("YellowFruit"))
                {
                    direction = (yellowTarget.transform.position - hit.collider.gameObject.transform.position).normalized;
                    hit.rigidbody.AddForceAtPosition(direction * forceAmp + force, hit.point);
                }

                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.green);
            }
        }
    }
}