using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public float speed = 4f;
    public GameObject Movetarget;

    public float LookAheadDistance = 10;

    Vector3 currentTarget;

    // Update is called once per frame
    void Update()
    {
        Quaternion playerRotation = Quaternion.LookRotation(Movetarget.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * 4f);

        //if our current target is active, move towards the target
        if (Movetarget.activeSelf)
        {
            Vector3 directionToDestination = Movetarget.transform.position - transform.position;
            Ray ray = new Ray(transform.position, directionToDestination);
            RaycastHit hit;
            //Debug.DrawRay(transform.position, ray.direction * LookAheadDistance, Color.red);
            bool hitRay = Physics.Raycast(ray, out hit, LookAheadDistance);
            Vector3 newDirection = directionToDestination;
            if (hitRay)
            {
                for (int i = 0; i < 180; i++)
                {
                    //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                    newDirection = Quaternion.Euler(0, i % 2 == 0 ? i : -1 * i, 0) * directionToDestination;
                    ray = new Ray(transform.position, newDirection);
                    hitRay = Physics.Raycast(ray, out hit, LookAheadDistance);
                    if (!hitRay)
                        break;

                }
            }

            //Debug.DrawRay(ray.origin, ray.direction * LookAheadDistance, Color.green);
            currentTarget = ray.origin + ray.direction * LookAheadDistance;
            /*
            if (Physics.Raycast(ray, out hit, LookAheadDistance))
            {
                currentTarget = Movetarget.transform.position;
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
            else
            {
                currentTarget = Movetarget.transform.position;
                Debug.DrawRay(ray.origin, ray.direction * LookAheadDistance, Color.green);
            }*/


            currentTarget.y = transform.position.y;
            //This will change our position to move our object towards our target destination.
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            other.gameObject.SetActive(false);
        }
    }
}
