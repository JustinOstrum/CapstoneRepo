using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DoorSwing());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
        }
    }

    public IEnumerator DoorSwing()
    {
        var i = .5f;

        while(i > 0)
        {
            i -= Time.deltaTime;

            door.transform.Rotate(0, -2f, 0, Space.World);

            yield return null;
        }
    }

    public IEnumerator CloseDoor()
    {
        var i = .5f;

        while (i > 0)
        {
            i -= Time.deltaTime;

            door.transform.Rotate(0, 2f, 0, Space.World);

            yield return null;            
        }
            
        door.transform.rotation = Quaternion.Euler(0, -37, 0);
    }
}
