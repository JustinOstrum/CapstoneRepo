using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour
{
    public Transform point;

    private void Update()
    {
        transform.position = point.transform.position;
    }
}
