using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFruitScript : MonoBehaviour
{
    Vector3 rotateVector = new Vector3(.1f,0,0);

    private void Update()
    {
        transform.Rotate(rotateVector);
    }
}
