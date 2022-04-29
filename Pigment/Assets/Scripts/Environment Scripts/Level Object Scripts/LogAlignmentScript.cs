using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAlignmentScript : MonoBehaviour
{
    public LogPileScript logPile;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            logPile.logCanSpawn = true;
        }
    }
}
