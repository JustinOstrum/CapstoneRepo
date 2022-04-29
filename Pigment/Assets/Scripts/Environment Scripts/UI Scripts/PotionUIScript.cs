using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUIScript : MonoBehaviour
{
    Vector3 rotateVector = new Vector3(0, .1f, 0);

    private void Update()
    {
        transform.Rotate(rotateVector);
    }
}
