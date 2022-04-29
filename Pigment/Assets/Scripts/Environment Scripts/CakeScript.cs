using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeScript : MonoBehaviour
{
    SlimeScript slimeScript;

    public bool cakehit;

    private void Start()
    {
        cakehit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        slimeScript = other.gameObject.GetComponent<SlimeScript>();

        if (slimeScript)
        {
            cakehit = true;
        }
    }
}
